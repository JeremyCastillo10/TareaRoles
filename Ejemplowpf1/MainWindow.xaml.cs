using System;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ejemplowpf1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var lista = RolesBLL.GetLista();
            DatosDataGrid.ItemsSource = lista;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            if(RolesBLL.Buscar(RolIDBox.Text) || RolIDBox.Text == "")
            {
                MessageBox.Show("Ingrese Otro RolID", "Fallo",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if(RolesBLL.BuscarAdmin(DescripcionTextBox.Text))
                {
                    MessageBox.Show("Solo puede haber un admin", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else{
                     Roles rol = new Roles(RolIDBox.Text, DescripcionTextBox.Text, FechaDatePicker.Text);
                     var paso = RolesBLL.Insertar(rol);

                     if(paso)
                        MessageBox.Show("Se ha creado con exito");
                     else 
                        MessageBox.Show("No se pudo crear el rol");
                }
                var lista = RolesBLL.GetLista();
                DatosDataGrid.ItemsSource = lista;
            }





        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            string id = RolIDBox.Text;
            if (RolesBLL.Buscar(RolIDBox.Text))
            {
                MessageBox.Show($"El RolID {id} fue encontrado" , "Exitoso",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible Encontrar no existe", "Fallo",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }        
        }

        private void EditarButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Ingrese el RolID a modificar.");
            if(RolesBLL.Buscar(RolIDBox.Text))
            {
              Roles rol = new Roles(RolIDBox.Text, DescripcionTextBox.Text, FechaDatePicker.Text);

             var paso = RolesBLL.Modificar(rol);
             MessageBox.Show("Editado con exito");

            }
            else{
                MessageBox.Show("No existe el id");
            }
            var lista = RolesBLL.GetLista();
            DatosDataGrid.ItemsSource = lista;
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
              if (RolesBLL.Eliminar(RolIDBox.Text))
            {
                MessageBox.Show("Registro Eliminado", "Exito",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible Eliminar", "Fallo",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
            var lista = RolesBLL.GetLista();
            DatosDataGrid.ItemsSource = lista;
            
        }

        
    }

}

