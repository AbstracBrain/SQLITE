using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SQLITE_BOOK.Clases;
using SQLite;
namespace SQLITE_BOOK
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        List<Libros> libros;
        public Principal()
        {
            InitializeComponent();
            libros = new List<Libros>();
            LeerBaseDatos();
        }
        void LeerBaseDatos()
        {
            using (SQLite.SQLiteConnection conn =
                new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Libros>();
                libros = (conn.Table<Libros>().ToList()).
                    OrderBy(c => c.Titulo).ToList();
            }
            if (libros != null)
            {
                lvLibros.ItemsSource = libros;
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            SQLITE_BOOK.MainWindow form = new SQLITE_BOOK.MainWindow();
            form.ShowDialog();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            SQLITE_BOOK.EliminarDatos form = new SQLITE_BOOK.EliminarDatos();
            form.ShowDialog();

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            SQLITE_BOOK.Editar form = new SQLITE_BOOK.Editar();
            form.ShowDialog();
        }
    }
}
