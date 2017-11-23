﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class HtmlGetter
    {
        public static string getString(string id)
        {
            if (id == "menu")
                return @"<button id='btnGet1' type='button' onclick='changeContent1()'>Get first</button> 
                    <button id='btnGet2' type='button' onclick='changeContent2()'>Get second</button>
                    <button id='btnGet3' type='button' onclick='changeContent3()'>Get third</button>
                    <button id='btnGet4' type='button' onclick='changeContent4()'>Show all cars</button> <span id='cont'></span> ";
            if (id == "showLogin")
                return @"<div class='containerr'>

      <form id='log'>
        <h2>Вход</h2>
        <input type='login' class='form-control' placeholder='Логин' required='' autofocus=''>
        <input type='password' class='form-control' placeholder='Пароль' required=''>
        <label class='checkbox'>
          <input type='checkbox' value='remember-me'> Запомнить меня
        </label>
        <button class='btn btn-lg btn-primary btn-block'>Войти</button> 
      </form>
      <button class='btn btn-lg btn-primary btn-block'>Регистрация</button>    
    </div>";
            if (id == "reg")
                return @"";
            if (id == "cont1")
                return @"<p /><button id='btnC1' type='button' onclick='alert(123);'>alert123</button>";
            if (id == "cont2")
                return @"<p />texttexttext<p /><button id='btnC2' type='button' onclick='alertAllCl();'>alertAllActiveUsers</button>";
            if (id == "cont3")
                return @"<p /><button id='btnC3' type='button' onclick='location.reload();'>logout</button>";
            if (id == "showCars")
            {
                const string quote = "\"";
                string result = @"<div>";
                var cars = (new DBConnectionString()).Автомобиль.ToArray();
                foreach (var car in cars)
                {
                    result += string.Format(
                        $@"<div>Автомобиль {car.Модель.Марка} {car.Модель.Модель1} от 
                            {car.Пользователь.Имя} всего за {car.Стоимость} в час!</div><button id='{car.id}' type='button' onclick='rentCar({quote + car.id + quote})'>Арендовать сейчас</button><br>");
                }
                result += "</div>";
                return result;
            }
            return "";
        }
    }

    public class User
    {
        public string Login { get; set; }
        public string MD5Pass { get; set; }

        public static User LoadUser(string login, string pass)
        {
            if (login == "asd")
            {
                return new User() { Login = login, MD5Pass = pass };
            }
            return null;
        }
    }

}
