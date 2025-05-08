using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace PryDamonteConexion
{
    public class ClsConexion
    {
        OleDbCommand Comando;
        OleDbConnection Conexion;
        OleDbDataAdapter Adaptador;

        string cadena;

        public ClsConexion()
        {
            cadena = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database1.accdb";
        }
        public void ListarDatos(DataGridView DgvDatos)
        {
            try
            {
                Conexion = new OleDbConnection(cadena);
                Comando = new OleDbCommand();

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = "SELECT * FROM Contactos";

                DataTable Contactos = new DataTable();
                Adaptador = new OleDbDataAdapter(Comando);
                Adaptador.Fill(Contactos);

                DgvDatos.DataSource = Contactos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
