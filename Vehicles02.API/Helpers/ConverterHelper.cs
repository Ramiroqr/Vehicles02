using System;
using System.Threading.Tasks;
using Vehicles02.API.Data;
using Vehicles02.API.Data.Entities;
using Vehicles02.API.Models;

namespace Vehicles02.API.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext context,
            ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public async Task<User> ToUserAsync(UserViewModel model, Guid imageId, bool isNew)
        {
            return new User
            {
                Address = model.Address,
                Document = model.Document,
                DocumentType = await _context.DocumentTypes.FindAsync(model.DocumetTypeId),
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Id = isNew ? Guid.NewGuid().ToString() : model.Id,
                ImageId = imageId,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Email,
                UserType = model.UserType,
            };
        }

        public UserViewModel ToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Address = user.Address,
                Document = user.Document,
                DocumetTypeId = user.DocumentType.Id,
                DocumentTypes = _combosHelper.GetComboDocumentTypes(),
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                ImageId = user.ImageId,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType,
            };
        }

    }
}
