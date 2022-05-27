using Microsoft.AspNetCore.SignalR;
using SignalrD1.Models;

namespace SignalrD1.Hubs
{
    public class ChatHub:Hub
    {
        signalrchatContext db;
        public ChatHub(signalrchatContext db)
        {
            this.db = db;
        }

        //public void sendmessage(string name , string mess)
        //{
        //    //save db
        //    message m = new message() { name = name, txt = mess };
        //    db.Add(m);
        //    db.SaveChanges();
        //
        //    //send data to all clients
        //    Clients.All.SendAsync("newmessage", name, mess);
        //}

        public void sendmessage(message m)
        {
            db.Add(m);
            db.SaveChanges();

            //send data to all clients
            Clients.All.SendAsync("newmessage", m);
        }
    }
}
