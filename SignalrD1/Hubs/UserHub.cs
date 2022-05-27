using Microsoft.AspNetCore.SignalR;
using SignalrD1.Models;

namespace SignalrD1.Hubs
{
    public class UserHub:Hub
    {
        signalrchatContext db;
        public UserHub(signalrchatContext db)
        {
            this.db = db;
        }

        public void adduser(string name, string address, int age)
        {
            //save db
            User u = new User() { Name = name, Address = address, Age = age };
            db.Add(u);
            db.SaveChanges();

            //db.Add(user);
            //db.SaveChanges();

            //send data to all clients
            Clients.All.SendAsync("newuser", name, address, age);
        }
    }
}
