using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Search_Whole_DB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static List<Tabelle> Tabellen;
        //------------------------------------------------------------------------------------------------
        private void TextBox_Suchfeld_TextChanged(object sender, EventArgs e)
        {
            if ((TextBox_Suchfeld.TextLength > 0) && !DropDown_TypAuswahl.SelectedItem.ToString().Equals(string.Empty))
            {
                Button_SucheStarten.Enabled = true;
            }
            else
            {
                Button_SucheStarten.Enabled = false;
            }
        }
        //------------------------------------------------------------------------------------------------
        private void DropDown_TypAuswahl_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((TextBox_Suchfeld.TextLength > 0) && !DropDown_TypAuswahl.SelectedItem.ToString().Equals(string.Empty))
            {
                Button_SucheStarten.Enabled = true;
            }
            else
            {
                Button_SucheStarten.Enabled = false;
            }
        }
        //------------------------------------------------------------------------------------------------
        private void Button_TypenErfassen_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Button_TypenErfassen.Invoke(new Action<bool>(s => { Button_TypenErfassen.Enabled = s; }), false);
                //Button_TypenErfassen.Enabled = false;
                var SQLBefehl = new OracleCommand("SELECT count(*) FROM USER_OBJECTS WHERE OBJECT_TYPE = 'TABLE'", Program.Hauptverbindung);
                SQLBefehl.CommandType = CommandType.Text;
                var LeseFunktion = SQLBefehl.ExecuteReader();
                SQLBefehl.FetchSize = SQLBefehl.RowSize * 1;
                LeseFunktion.Read();
                StatusBalken.Invoke(new Action<int>(s => { StatusBalken.Minimum = s; }), 0);
                StatusBalken.Invoke(new Action<int>(s => { StatusBalken.Maximum = s; }), LeseFunktion.GetInt32(0));
                StatusBalken.Invoke(new Action<int>(s => { StatusBalken.Value = s; }), 0);
                //StatusBalken.Minimum = 0;
                //StatusBalken.Maximum = LeseFunktion.GetInt32(0);
                //StatusBalken.Value = 0;
                LeseFunktion.Close();
                
                Program.Typen.Clear();
                SQLBefehl = new OracleCommand("SELECT OBJECT_NAME FROM USER_OBJECTS WHERE OBJECT_TYPE = 'TABLE'", Program.Hauptverbindung);
                LeseFunktion = SQLBefehl.ExecuteReader();
                SQLBefehl.FetchSize = SQLBefehl.RowSize * 10240;
                SQLBefehl.Prepare();
                while (LeseFunktion.Read())
                {
                    Tabellen.Add(new Tabelle(LeseFunktion.GetString(0)));
                    StatusBalken.Invoke(new Action(() => StatusBalken.Value++));
                    //StatusBalken.Value++;
                }
                LeseFunktion.Close();
                SQLBefehl.CommandText = "select TABLE_NAME, COLUMN_NAME, DATA_TYPE, DATA_LENGTH from user_tab_columns";
                LeseFunktion = SQLBefehl.ExecuteReader();
                SQLBefehl.FetchSize = SQLBefehl.RowSize * 100 * Tabellen.Count;
                SQLBefehl.Prepare();
                Tabelle GesuchteTabelle;
                string DatenTyp;
                while (LeseFunktion.Read())
                {
                    GesuchteTabelle = TabelleSuchen(LeseFunktion.GetString(0));
                    if (!ReferenceEquals(GesuchteTabelle, null))
                    {
                        DatenTyp = LeseFunktion.GetString(2);
                        GesuchteTabelle.Spalten.Add(new Spalte(LeseFunktion.GetString(1), DatenTyp, LeseFunktion.GetInt32(3)));
                        if (!Program.Typen.Contains(DatenTyp))
                        {
                            Program.Typen.Add(DatenTyp);
                        }
                    }
                }
                LeseFunktion.Close();
                StatusBalken.Invoke(new Action<int>(s => { StatusBalken.Value = s; }), 0);
                DropDown_TypAuswahl.Invoke(new Action(() => DropDown_TypAuswahl.Items.Clear()));
                DropDown_TypAuswahl.Invoke(new Action(() => DropDown_TypAuswahl.Items.AddRange(Program.Typen.ToArray())));
                DropDown_TypAuswahl.Invoke(new Action<bool>(s => { DropDown_TypAuswahl.Enabled = s; }), true);
                //DropDown_TypAuswahl.Enabled = true;
                if ((TextBox_Suchfeld.TextLength > 0) && !DropDown_TypAuswahl.SelectedItem.ToString().Equals(string.Empty))
                {
                    Button_SucheStarten.Invoke(new Action<bool>(s => { Button_SucheStarten.Enabled = s; }), true);
                    //Button_SucheStarten.Enabled = true;
                }
            });
        }
        //------------------------------------------------------------------------------------------------
        private void Button_SucheStarten_Click(object sender, EventArgs e)
        {
            TextBox_Suchfeld.Enabled = false;
            Button_SucheStarten.Enabled = false;
            DropDown_TypAuswahl.Enabled = false;
            ListBox_Ausgabe.Items.Clear();
            OracleDataReader LeseFunktion;
            int TrefferInSpalte;
            StatusBalken.Value = 0;
            var TypAuswahl = DropDown_TypAuswahl.SelectedItem.ToString();
            var SuchText = TextBox_Suchfeld.Text.ToLower();
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < Tabellen.Count; i++)
                {
                    for (int i2 = 0; i2 < Tabellen[i].Spalten.Count; i2++)
                    {
                        if (Tabellen[i].Spalten[i2].DatenTyp.Equals(TypAuswahl))
                        {
                            StatusBalken.Invoke(new Action(() => StatusBalken.Maximum++));
                            //StatusBalken.Maximum++;
                        }
                    }
                }
                var SQLBefehl = new OracleCommand(string.Empty, Program.Hauptverbindung);
                for (int i = 0; i < Tabellen.Count; i++)
                {
                    for (int i2 = 0; i2 < Tabellen[i].Spalten.Count; i2++)
                    {
                        if (Tabellen[i].Spalten[i2].DatenTyp.Equals(TypAuswahl))
                        {
                            SQLBefehl.CommandText = string.Format("SELECT Count(*) From {0} Where Lower({1}) Like '{2}' ", Tabellen[i].Name, Tabellen[i].Spalten[i2].Name, SuchText);
                            LeseFunktion = SQLBefehl.ExecuteReader();
                            SQLBefehl.FetchSize = SQLBefehl.RowSize * 10240;
                            SQLBefehl.Prepare();
                            LeseFunktion.Read();
                            TrefferInSpalte = LeseFunktion.GetInt32(0);
                            LeseFunktion.Close();
                            if (TrefferInSpalte > 0)
                            {
                                ListBox_Ausgabe.Invoke(new Action(() => ListBox_Ausgabe.Items.Add(string.Format("Anzahl an Treffer:{0}, Tabelle:{1}, Spalte: {2}", TrefferInSpalte, Tabellen[i].Name, Tabellen[i].Spalten[i2].Name))));
                                //ListBox_Ausgabe.Items.Add(string.Format("Anzahl an Treffer:{0}, Tabelle:{1}, Spalte: {2}", TrefferInSpalte, Tabellen[i].Name, Tabellen[i].Spalten[i2].Name));
                            }
                            StatusBalken.Invoke(new Action(() => StatusBalken.Value++));
                            //StatusBalken.Value++;
                        }
                    }
                }
                TextBox_Suchfeld.Invoke(new Action<bool>(s => { TextBox_Suchfeld.Enabled = s; }), true);
                Button_SucheStarten.Invoke(new Action<bool>(s => { Button_SucheStarten.Enabled = s; }), true);
                DropDown_TypAuswahl.Invoke(new Action<bool>(s => { DropDown_TypAuswahl.Enabled = s; }), true);
                //TextBox_Suchfeld.Enabled = true;
            });
        }

        private void Button_Verbinden_Click(object sender, EventArgs e)
        {
            Tabellen = new List<Tabelle>();
            //Hauptverbindung wird aufgebaut
            var oraDB = "Data Source=(DESCRIPTION="
             + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=...)(PORT=...)))"//Hier IP und Port angeben
             + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=...)));"//Hier DBName angeben
             + "User Id=...;Password=...;"//Hier SUSER Namen und Passwort angeben
             + "Max Pool Size=1000;";
            Program.Typen = new List<string>();
            Program.Hauptverbindung = new OracleConnection(oraDB);
            Program.Hauptverbindung.Open();
            Button_Verbinden.Enabled = false;
            Button_TypenErfassen.Enabled = true;
        }

        private Tabelle TabelleSuchen(string Name)
        {
            for (int i = 0; i < Tabellen.Count; i++)
            {
                if (Tabellen[i].Name.Equals(Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return Tabellen[i];
                }
            }
            return null;
        }
    }
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    internal sealed class Spalte
    {
        public Spalte(string Name, string DatenTyp, int MaxBytesGröße)
        {
            this.Name = Name;
            this.DatenTyp = DatenTyp;
            this.MaxBytesGröße = MaxBytesGröße;
        }
        public string Name { get; set; }
        public string DatenTyp { get; set; }
        public int MaxBytesGröße { get; set; }
    }
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    internal sealed class Tabelle
    {
        public Tabelle(string Name)
        {
            this.Name = Name;
            this.Spalten = new List<Spalte>();
        }
        public string Name { get; set; }
        public List<Spalte> Spalten { get; set; }
        //------------------------------------------------------------------------------------------------
        /*public bool SpaltenAdaptivHinzufügen(OracleCommand SQLBefehl)
        {
            SQLBefehl.CommandText = string.Format("SELECT * FROM {0}", Name);
            var LeseFunktion = SQLBefehl.ExecuteReader();
            SQLBefehl.FetchSize = SQLBefehl.RowSize * 10240;
            LeseFunktion.Read();
            var rows = LeseFunktion.GetSchemaTable().Rows;
            DataRow row;
            for (int i = 0; i < rows.Count; i++)
            {
                row = rows[i];
                var CurDataType = LeseFunktion.GetDataTypeName(i);
                Spalten.Add(new Spalte(LeseFunktion.GetName(i), CurDataType, (int)row["ColumnSize"]));
            }
            LeseFunktion.Close();
            return true;
        }*/
    }
}
