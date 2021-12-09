using System;
using System.Linq;
using System.Threading.Tasks;
using Vehicles02.API.Data.Entities;
using Vehicles02.API.Helpers;
using Vehicles02.Common.Enums;

namespace Vehicles02.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckVehiclesTypeAsync();
            await CheckBrandsAsync();
            await CheckDocumentTypesAsync();
            await CheckProceduresAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Ramiro", "Quispe", "ramiro@yopmail.com", "311 322 4620", "Calle Luna calle Sol", UserType.Admin);
            await CheckUserAsync("2020", "Juan", "Zuluaga", "zulu@yopmail.com", "311 322 458", "Calle Luna calle Sol", UserType.User);
            await CheckUserAsync("3030", "Ledys", "Bedoya", "ledys@yopmail.com", "311 322 458", "Calle Luna calle Sol", UserType.User);
            await CheckUserAsync("4040", "Sandra", "Lopera", "sandra@yopmail.com", "311 322 4620", "Calle Luna calle Sol", UserType.Admin);

        }

        private async Task CheckUserAsync(string document, string firstName, string lastName, string email, string phoneNumber, string address, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Address = address,
                    Document = document,
                    DocumentType = _context.DocumentTypes.FirstOrDefault(x => x.Descripcion == "Cédula"),
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckProceduresAsync()
        {
            if (!_context.Procedures.Any())
            {
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Alineación" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Lubricación de suspención delantera" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Lubricación de suspención trasera" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Frenos delanteros" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Frenos traseros" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Líquido frenos delanteros" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Líquido frenos traseros" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Calibración de válvulas" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Alineación carburador" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Aceite motor" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Aceite caja" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Filtro de aire" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Sistema eléctrico" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Guayas" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio llanta delantera" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio llanta trasera" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Reparación de motor" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Kit arrastre" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Banda transmisión" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio batería" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Lavado sistema de inyección" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Lavada de tanque" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio de bujia" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio rodamiento delantero" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio rodamiento trasero" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Accesorios" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDocumentTypesAsync()
        {
            if (!_context.DocumentTypes.Any())
            {
                _context.DocumentTypes.Add(new DocumentType { Descripcion = "Cédula" });
                _context.DocumentTypes.Add(new DocumentType { Descripcion = "Tarjeta de Identidad" });
                _context.DocumentTypes.Add(new DocumentType { Descripcion = "DNI" });
                _context.DocumentTypes.Add(new DocumentType { Descripcion = "Pasaporte" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckBrandsAsync()
        {
            if (!_context.Brands.Any())
            {
                _context.Brands.Add(new Brand { Descripcion = "Ducati" });
                _context.Brands.Add(new Brand { Descripcion = "Harley Davidson" });
                _context.Brands.Add(new Brand { Descripcion = "KTM" });
                _context.Brands.Add(new Brand { Descripcion = "BMW" });
                _context.Brands.Add(new Brand { Descripcion = "Triumph" });
                _context.Brands.Add(new Brand { Descripcion = "Victoria" });
                _context.Brands.Add(new Brand { Descripcion = "Honda" });
                _context.Brands.Add(new Brand { Descripcion = "Suzuki" });
                _context.Brands.Add(new Brand { Descripcion = "Kawasaky" });
                _context.Brands.Add(new Brand { Descripcion = "TVS" });
                _context.Brands.Add(new Brand { Descripcion = "Bajaj" });
                _context.Brands.Add(new Brand { Descripcion = "AKT" });
                _context.Brands.Add(new Brand { Descripcion = "Yamaha" });
                _context.Brands.Add(new Brand { Descripcion = "Chevrolet" });
                _context.Brands.Add(new Brand { Descripcion = "Mazda" });
                _context.Brands.Add(new Brand { Descripcion = "Renault" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckVehiclesTypeAsync()
        {
            if (!_context.VehicleTypes.Any())
            {
                _context.VehicleTypes.Add(new VehicleType { Descripcion = "Carro" });
                _context.VehicleTypes.Add(new VehicleType { Descripcion = "Moto" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
