using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminRepo : Repo, IRepo<Admin, int, bool>
    {
        public bool Create(Admin obj)
        {
            db.Admins.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = Get(id);
            db.Admins.Remove(data);
            return db.SaveChanges() > 0;
        }

        public Admin Get(int id)
        {
            return db.Admins.Find(id);

        }

        public List<Admin> GetALL()
        {
            return db.Admins.ToList();
        }

        public bool Update(Admin obj)
        {
            var st = Get(obj.AdminID);
            db.Entry(st).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
