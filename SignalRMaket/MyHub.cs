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

        //[HubMethodName("OnDisconnected")]
        //public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        //{
        //    var connection = new DBConnectionString();
        //    var item = connection.Пользователь.FirstOrDefault(x => x.id == Users.UserByCid(cid)._User.id);
        //    if (item != null)
        //    {
        //        //сonnection.Пользователь.Remove(item);
        //        var id = Users.UserByCid(cid)._User.id;
        //        Clients.All.onUserDisconnected(id, item.Логин);
        //    }

        //    return base.OnDisconnected(stopCalled);
        //}

        [HubMethodName("getHtmlSv")]
        public string GetHtml(string tag)
        {
            return HtmlGetter.getString(tag);
        }


        [HubMethodName("getHtmlSvPolz")]
        public string getStringVladelec(string tag)
        {
            return HtmlGetter.getStringVladelec(tag, Users.UserByCid(cid)._User);
        }
        
        [HubMethodName("getHtmlWithIdSv")]
        public string GetHtmlWithId(string tag, string guid)
        {
            return HtmlGetter.getStringWithId(tag, guid);
        }

        [HubMethodName("getHtmlFilterCars")]
        public string GetHtmlFilterCars(string tag, string dostupnost, int? min, int? max)
        {
            return HtmlGetter.GetFilteredString(tag, dostupnost, min, max);
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

        public void RentCar(string carId, int hours)
        {
            if (Users.UserByCid(cid) == null)
            {
                Clients.Caller.alertFuncCl("Авторизуйся, пёс");
            }
            else
            {
                Guid carGuid = new Guid(carId);
                var connection = new DBConnectionString();
                var car = connection.Автомобиль.Find(carGuid);
                if (!car.Доступность)
                    Clients.Caller.alertFuncCl("Машина занята");
                else
                {
                    Schedule.RentCar(carGuid, hours);
                    car.Доступность = false;
                    connection.Заказ.Add(new Заказ() { id = Guid.NewGuid(), idАвтомобиль = car.id, idПользователь = Users.UserByCid(cid)._User.id, ДатаВремяНачалаАредны = DateTime.Now, ДатаВремяКонцаАренды = DateTime.Now.AddHours(hours) });
                    connection.SaveChanges();
                    Clients.Caller.alertFuncCl($"Вы арендовали {car.Модель.Марка} {car.Модель.Модель1} за {car.Стоимость}");
                }
            }
        }


           public void saveOtziv(Guid carId, Guid zakId, int rait, string Text)
        {
            var connection = new DBConnectionString();
            connection.Отзыв.Add(new Отзыв() { id = Guid.NewGuid(), Рейтинг = rait, Текст = Text, idЗаказ = zakId });
            connection.SaveChanges();

        }


        public void Addauto(string model, string opis, decimal stoim, string file)
        {
            model = model.Trim();
            var connection = new DBConnectionString();
            var models = connection.Модель.AsEnumerable().Select(x => Tuple.Create(x.Марка + " " + x.Модель1, x.id)).ToArray();
            var mod = models.Single(x => x.Item1 == model).Item2;
            connection.Автомобиль.Add(new Автомобиль() { id = Guid.NewGuid(), Доступность = true, Описание = opis , Стоимость = stoim, Фото = file , idМодель = mod , idВладелец = Users.UserByCid(cid)._User.id});
            connection.SaveChanges();
            Clients.Caller.showMenupolzSdan();
            
        }

        public void DeltCar(string carId)
        {
            var connection = new DBConnectionString();
            var car = connection.Автомобиль.Single(o => o.id.ToString() == carId);
            connection.Автомобиль.Remove(car);
            connection.SaveChanges();
            //  Clients.CallerState.showMenupolzSdan();

            Clients.Caller.showMenupolzSdan();
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