using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;

namespace DoAn
{
    public class mapAccounts
    {
        QLWebShiseidoEntities3 db = new QLWebShiseidoEntities3();
        
        //1. Tìm kiếm
        public Accounts TimKiem(string username, string password)
        {
            var user = db.Accounts.Where(m => m.UserName == username & m.Password == password).ToList();
            if(user.Count > 0)
            {
                return user[0];
            }
            else
            {
                return null;
            }
        }
        //2. Danh sách
       public List<Accounts> DanhSach()
        {
            var users = db.Accounts.ToList();
            return users;
        }
        //3.Thêm mới: sử dụng tham số lẻ, sử dụng tham số đối tượng
        public void ThemMoi(string hoTen, string sdt, string hinhAnh)
        {
            //tạo đối tượng và gán giá trị cho đối tượng mới
            Accounts acc = new Accounts();
            acc.FullName = hoTen;
            acc.Phone = sdt;
            acc.Avatar = hinhAnh;
            //add vào list đối tượng trong database
            db.Accounts.Add(acc);
            //Lưu vào database
            db.SaveChanges();
        }

        public bool ThemMoi(Accounts acc)
        {
            try
            {
                //add vào list đối tượng trong database
                db.Accounts.Add(acc);
                //Lưu vào database
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}