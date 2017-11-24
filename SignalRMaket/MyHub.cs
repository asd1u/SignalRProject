using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using ORM;
using System.Security.Cryptography;
using System.Text;

namespace SignalRMaket
{
    [HubName("myHub")]
    public class MyHubSv : Hub
    {
        string cid
        {
            get
            {
                string clientId = "";
                if (Context.QueryString["clientId"] != null)
                {
                    clientId = Context.QueryString["clientId"];
                }
                if (string.IsNullOrWhiteSpace(clientId))
                {
                    clientId = Context.ConnectionId;
                }
                return clientId;
            }
        }



        public override Task OnDisconnected(bool stopCalled)
        {
            Users.DisconnectUser(Users.UserByCid(cid));
            return base.OnDisconnected(stopCalled);
        }

        [HubMethodName("getHtmlSv")]
        public string GetHtml(string tag)
        {
            return HtmlGetter.getString(tag);
        }

        [HubMethodName("logInSv")]
        public void LogIn(string user, string pass)
        {
            var пользователь = (new DBConnectionString()).Пользователь.FirstOrDefault(x => x.Логин == user);
            //TODO добавить хэширование паролей
            if (user != "")
            {
                if (pass != "")
                {
                    if (пользователь != null)
                    {
                        if (пользователь.Пароль == MD5Hash(pass))
                        {
                            Users.ConnectUser(new WebUser(пользователь, cid));
                            Clients.Caller.onSuccessfulLoginCl();
                        }
                        else
                            Clients.Caller.alertFuncCl("Неверный пароль");

                    }
                    else
                        Clients.Caller.alertFuncCl("Такого пользователя не существует");
                }
                else
                    Clients.Caller.alertFuncCl("Введите пароль");
            }
            else
                Clients.Caller.alertFuncCl("Введите логин");
        }

        public void Registr(string user, string pass, string name, string fname, string oname)
        {

            var пользователь = (new DBConnectionString()).Пользователь.FirstOrDefault(x => x.Логин == user);
            if (пользователь == null)
            {
                if (pass == "")
                    Clients.Caller.alertFuncCl("Введите пароль");
                else
                {
                    if (fname == "" || name == "" || oname == "")
                        Clients.Caller.alertFuncCl("Введите Ваши личные данные");
                    else
                    {
                        var connection = new DBConnectionString();
                        pass = MD5Hash(pass);
                        connection.Пользователь.Add(new Пользователь() { id = Guid.NewGuid(), Логин = user, Пароль = pass, Имя = name, Фамилия = fname, Отчество = oname });
                        connection.SaveChanges();
                        Clients.Caller.alertFuncCl("Регистрация прошла успешна! Войдите в систему.");

                        }

                }
                
            }
            else
                Clients.Caller.alertFuncCl("Логин занят");


        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public void RentCar(string carId)
        {
            Guid carGuid = new Guid(carId);
            var car = (new DBConnectionString()).Автомобиль.Find(carGuid);
            Clients.Caller.alertFuncCl($"Вы арендовали {car.Модель.Марка} {car.Модель.Модель1} за {car.Стоимость}");
        }

        [HubMethodName("alertAllSv")]
        public void AlertAll(string mes)
        {
            var u = Users.UserByCid(cid);
            if (u == null)
            {
                Clients.Caller.alertFuncCl("authorization required!");
                return;
            }
            Clients.All.alertFuncCl(string.Format("message from {0}:\n {1}", u._User.Имя, mes));
        }


    }
}