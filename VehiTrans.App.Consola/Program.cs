using System;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Consola
{
    class Program
    {
        /* Referencia a RepositorioMecanico a traves de la interfaz*/
        private static IRepositorioPropietario _repoPropietario = new RepositorioPropietario(new Persistencia.AppContext());
        private static IRepositorioConductor _repoConductor = new RepositorioConductor(new Persistencia.AppContext());
        private static IRepositorioMecanico _repoMecanico = new RepositorioMecanico(new Persistencia.AppContext());
        private static IRepositorioVehiculoTipo _repoVehiculoTipos = new RepositorioVehiculoTipo(new Persistencia.AppContext());
        private static IRepositorioVehiculo _repoVehiculo = new RepositorioVehiculo(new Persistencia.AppContext());

        static void Main(string[] args)

        {
            Console.WriteLine("Hello, World!");
            //AddMecanico();
            //BuscarMecanico(1);
            //AddPropietario();
            //AddConductor();
            //AddVehiculosTipo("Buseta");
            //AddVehiculosTipo("Microbus");
            AddVehiculo();
        }
        private static void AddMecanico()
        {
            var Mecanico = new Mecanico
            {
                Documento = "1012932121",
                Nombre = "Mathias",
                Apellidos = "Velasco Piña",
                Telefono = "mathias231@gmail.com",
                Usuario = "Mathias1012",
                Contraseña = "Barcelona123",
            };

            _repoMecanico.AddMecanico(Mecanico);

        }

        private static void AddPropietario()
        {
            var propietario = new Propietario
            {
                Documento = "10902356987",
                Nombre = "Marcos",
                Apellidos = "Parra",
                Telefono = "marcosP@gmail.com",
                Usuario = "MarcosP",
            };

            _repoPropietario.AddPropietario(propietario);
        }

        private static void AddConductor()
        {
            var conductor = new Conductor
            {
                Documento = "109012345",
                Nombre = "Pedro",
                Apellidos = "Perez",
                Telefono = "PedropP@gmail.com",
                Usuario = "Pedrop",
            };

            _repoConductor.AddConductor(conductor);
        }

        private static void AddVehiculosTipo(String VVTipo)
        {
            var VVehiculosTipo = new VehiculoTipo
            {
                Descripcion = VVTipo,
            };

            // Console.WriteLine("Inicio");
            _repoVehiculoTipos.AddVehiculoTipo(VVehiculosTipo);
            // Console.WriteLine("Sale");

        }

        private static void AddVehiculo()
        {
            var VVehiculo = new Vehiculo
            {
                Placa = "CUC123",
                Marca = "Toyota",
                Modelo = "2021",
                VehiculoTipoId = 1,
                CantidadPasajeros = 30,
                CilindrajeMotor = 3000,
                PropietarioId = 1,
                ConductorId = 1,
                MecanicoId = 1,

            };

            Console.WriteLine("Inicio V");
            _repoVehiculo.AddVehiculo(VVehiculo);
            Console.WriteLine("Sale V");

        }


        private static void BuscarMecanico(int idMecanico)
        {
            var Mecanico = _repoMecanico.GetMecanico(idMecanico);
            Console.WriteLine(Mecanico.Nombre + " " + Mecanico.Apellidos);
        }




    }


}