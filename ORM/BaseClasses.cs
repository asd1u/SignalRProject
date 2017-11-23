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
            if (id == "user")
                return "<p>Вы уже вошли</p>";
            if (id == "menu")
                return @" <div class='splash'>
                        <div class='container'>
                         <p>Аренда автомобилей в Перми</p>
                          </div>
                          </div>
                           <div class='cars'>
                              <div class='page-header'>
                                 <h1 class='text-right'>Наши автомобили</h1>
                             </div>
                          <div class='container marketing'>
                <!-- Three columns of text below the carousel -->
                <div class='rows'>
                    <div class='col-lg-4'>
                        <img class='img-fluid' data-src='pic/pic6.jpg/140x140' alt='200x200' src='pic/pic6.jpg' style='width: 300px; height: 200px;'>
                        <div class='marka'>
                            <p> Какая-то машинка  </p>
                        </div>
                        <p>5000 Руб./Сутки</p>



                    </div><!-- /.col-lg-4 -->
                    <div class='col-lg-4'>
                        <img class='img-fluid' data-src='pic/pic7.jpg/140x140' alt='200x200' src='pic/pic7.jpg' style='width: 300px; height: 200px;'>
                        <div class='marka'>
                            <p> Какая-то машинка </p>
                        </div>
                        <p> 10000 Руб./Сутки</p>
                    </div>

                    <div class='col-lg-4'>
                        <img class='img-fluid' data-src='pic/pic8.jpg/140x140' alt='200x200' src='pic/pic8.jpg' style='width: 300px; height: 200px;'>
                        <div class='marka'>
                            <p> Какая-то машинка  </p>
                        </div>
                        <p>13000 Руб./Сутки</p>
                    </div>


                    <!-- /.col-lg-4 -->
                </div><!-- /.row -->
            </div>

            <p><a class='btn btn-inverse btn-lg'  role='button'> Посмотреть все автомобили  →</a></p>



        </div>

        <div class='sucsess'>
            <div class='page-header'>
                <h1>Все о компании</h1>
            </div>
            <div class='row'>
                <div class='col-lg-6 ml-auto'>
                    <img class='img-fluid' data-src='holder.js/140x140' alt='350x200' src='pic/office.jpg' style='width: 450px; height: 300px;'>
                </div>

                <div class='col-lg-5 ml-auto'>
                    <p> ООО  'MEOWavto' является одной из крупнейших компаний Пермского края на рынке транспортных услуг. Начав свою деятельность в 2007 году, на сегодняшний день прочно удерживает лидирующие позиции, завоевав доверие многочисленных клиентов.  </p>
                    <p>
                        Мы предлагаем Вам широкий спектр транспортных услуг: аренда автомобилей без водителя; аренда легковых автомобилей с водителем;
                        аренда автомобиля на свадьбу;
                        грузовые перевозки;
                        пассажирские перевозки ( аренда автобусов и микроавтобусов; трансфер (аэропорт 'Большое Савино', железнодорожный вокзал Пермь II);
                        аренда спецтехники;
                        услуги автосервиса.
                    </p>
                </div>
            </div>

        </div>
    

    <!-- О нас -->
    <div class='where'>
        <div class='page-header'>
            <h1 class='text-center'>Контакты</h1>
        </div>
        <div class='row'>
            <div class='col-lg-5 ml-auto'>
                <p> Оставить заявку можно любым удобным для Вас способом:</p>
                <p>   через сайт; </p>
                <p>   по e-mail: meow@gmail.ru; </p>
                <p>   по тел. 8 800 555 55 35;</p>
            </div>
            <div class='col-lg ml-auto'>
                <img class='img-fluid' data-src='holder.js/140x140' alt='350x200' src='pic/cars.jpg' style='width: 450px; height: 300px;'>
            </div>
        </div>
    </div>


    <div class='footer'>
        <p class='pull-right'><a>Вернуться наверх</a></p>
        <p>© 2017 Company, Inc. MeowCat </p>
    </div>

";
            if (id == "showLogin")
                return @"<div class='containerr'>   
                            <form id = 'log' '>
                                 <h2> Вход </h2>
                                  <input id='tbLogin' type = 'login' class='form-control' placeholder='Логин' required='' autofocus=''>
                                  <input id='tbPassword' type = 'password' class='form-control' placeholder='Пароль' required=''>
                                <button class='btn btn-lg btn-primary btn-block' onclick='logInCl(); return false;' >Войти</button> 
                            </form>
                        <button class='btn btn-lg btn-primary btn-block onclick='reg()'>Регистрация</button>    
                        </div> ";
            if (id == "Onas")
                return @"<div class='sucsess' >
            <div class='page-header'>
                <h1>Все о компании</h1>
            </div>
            <div class='row'>
                <div class='col-lg-6 ml-auto'>
                    <img class='img-fluid' data-src='holder.js/140x140' alt='350x200' src='pic/office.jpg' style='width: 450px; height: 300px;'>
                </div>

                <div class='col-lg-5 ml-auto'>
                    <p> ООО  'MEOWavto' является одной из крупнейших компаний Пермского края на рынке транспортных услуг. Начав свою деятельность в 2007 году, на сегодняшний день прочно удерживает лидирующие позиции, завоевав доверие многочисленных клиентов.  </p>
                    <p>
                        Мы предлагаем Вам широкий спектр транспортных услуг: аренда автомобилей без водителя; аренда легковых автомобилей с водителем;
                        аренда автомобиля на свадьбу;
                        грузовые перевозки;
                        пассажирские перевозки ( аренда автобусов и микроавтобусов; трансфер (аэропорт 'Большое Савино', железнодорожный вокзал Пермь II);
                        аренда спецтехники;
                        услуги автосервиса.
                    </p>
                </div>
            </div>

        </div>
 <div class='footer'>
        <p>© 2017 Company, Inc. MeowCat </p>
    </div>";
            if (id == "contact")
                return @"<div class='where'>
        <div class='page-header'>
            <h1 class='text-center'>Контакты</h1>
        </div>
        <div class='row'>
            <div class='col-lg-5 ml-auto'>
                <p> Оставить заявку можно любым удобным для Вас способом:</p>
                <p>   через сайт; </p>
                <p>   по e-mail: meow@gmail.ru; </p>
                <p>   по тел. 8 800 555 55 35;</p>
            </div>
            <div class='col-lg ml-auto'>
                <img class='img-fluid' data-src='holder.js/140x140' alt='350x200' src='pic/cars.jpg' style='width: 450px; height: 300px;'>
            </div>
        </div>
    </div>


    <div class='footer'>
        <p>© 2017 Company, Inc. MeowCat </p>
    </div>";
            if (id == "reg")
                return @"<div class='reg'>
<form id = 'regis'>
<h2> Регистрация </h2>
<input id = 'tbLogin' type = 'login' class='form-control' name = 'login' placeholder = 'Логин' required='' autofocus=''> 
<input id = 'tbPassword' type = 'password' class='form-control' name = 'password' placeholder = 'Пароль' required='' >
<input id = 'tbName' type = 'text' class='form-control' name = 'Name' placeholder = 'Имя' required='' >
<input id = 'tbFname' type = 'text' class='form-control' name = 'Fname' placeholder = 'Фамилия' required='' > 
<input id = 'tbOname' type = 'text' class='form-control' name = 'Oname' placeholder = 'Отчество' required='' > 
<br>
<button class='btn btn-lg btn-primary btn-block' id = 'btnReg' onclick='reg(); return false;' > Зарегистрироваться </ button > 
</form>
<button class='btn btn-lg btn-primary btn-block' id = 'btnExit' onclick='showMain()' > Выйти </ button >
</div>";
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
