using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DataAccessLayer.Abstract;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void TDelete(Contact entity)
        {
            throw new NotImplementedException();
        }

        public Contact TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> TGetListAll()
        {
            return _contactDal.GetListAll();
        }

        public void TInsert(Contact entity)
        {
            _contactDal.Insert(entity); 
        }

        public void TUpdate(Contact entity)
        {
            throw new NotImplementedException();
        }
    }
}
