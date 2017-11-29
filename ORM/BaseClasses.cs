using System;
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
            if (id == "menuTablpolz")
            {
                const string quote = "\"";
                string result = @"
                                <div class='allpeople'>
                                    <table class='table table-bordered table-hover'>
                                <thead>
                                 <tr>
                                 <th>Логин</th>
                                 <th>Имя</th>
                                 <th>Фамилия</th>
                                 <th>Отчество</th>
                                 <th>Статус</th>
                                <th></th>
                                 </tr>
                                 </thead>
                                 <tbody>";
                var users = (new DBConnectionString()).Пользователь.ToArray();
                foreach (var user in users)
                {
                    result += string.Format(
                        $@" <tr>
                         <td>{user.Логин}</td>
                         <td>{user.Имя}</td>
                         <td>{user.Фамилия}</td>
                         <td>{user.Отчество}</td>");
                    if (user.Администратор == true)
                        result += string.Format("<td>Администратор</td>");
                    else
                        result += string.Format("<td>Пользователь</td>");

                    result += string.Format($@"<td><button type = 'button' class= 'btn btn-primary' onclick='delPolz({quote + user.id + quote})'>Удалить</button>
                             <a href='#change' onclick = 'Profil({quote + user.id + quote},{quote + user.Логин + quote},{quote + user.Имя + quote},{quote + user.Фамилия + quote},{quote + user.Отчество + quote},{quote + user.Администратор + quote})' class='btn btn-primary' data-toggle='modal'>Редактировать профиль</a>  
                             </td></tr>");

                }
                result += $@"</tbody></table></div>
                     <div id='change' class='modal fade'>
                  <div class='modal-dialog'>
                    <div class='modal-content'>
                      <div class='modal-header'>
                        <button type = 'button' class='close' data-dismiss='modal' aria-hidden='true'>×</button>
                        <h4 class='modal-title'>Изменение данных о пользователе</h4>
                      </div>

    
                          <div class='modal-body'>
                                <input id = 'Userid' hidden = ''>
                                <label> Логин: </label><br>
                                <input id = 'inLogin' type = 'login' class='form-control' name = 'login' placeholder = 'Логин' required='' autofocus=''> 
                                <label> Пароль: </label><br>
                                <input id = 'inPassword' type = 'password' class='form-control' name = 'password' placeholder = 'Введите, чтобы изменить пароль'  required='' >
                                <label> Имя: </label><br>
                                <input id = 'inName' type = 'text' class='form-control'   name = 'Name' placeholder = 'Имя'  required='' >
                                <label> Фамилия: </label><br>
                                <input id = 'inFname' type = 'text' class='form-control' name = 'Fname' placeholder = 'Фамилия'  required='' > 
                                <label> Отчество: </label><br>
                                <input id = 'inOname' type = 'text' class='form-control' name = 'Oname' placeholder = 'Отчество'  required='' >
                                <label> Статус: </label><br>
                                <select class='selectpicker' id = 'inStatus'>
                                    <option>Администратор</option>
                                     <option>Пользователь</option>
                                 </select>
            
                        </div>

                          
                <div class= 'modal-footer'>
                        <button type = 'button' onclick = 'saveProfil()' class='btn btn-primary' data-dismiss='modal'>Сохранить изменения</button>
                      </div> ";
                return result;
            }

            if (id == "user2")
                return @"<div id='buttonlogin'><button class='btn-link btn-lg' onclick='showLogin()'>Вход</button></div>";
            if (id == "menu")
            {
                string result = string.Format($@"<div class='splash'>
            <div class='container'>
                <p>Аренда автомобилей в Перми</p>
            </div>
        </div>
        <div class='cars'>
            <div class='page-header'>
                <h1 class='text-right'>Наши автомобили</h1>
            </div>
            <div class='container marketing'>
                <div id='randomcars' class='rows'>");
                //<div class='container marketing'>
                //<!-- Three columns of text below the carousel -->
                //<div class='rows'>
                //    <div class='col-lg-4'>
                //        <img class='img-fluid' data-src='pic/pic6.jpg/140x140' alt='200x200' src='pic/pic6.jpg' style='width: 300px; height: 200px;'>
                //        <div class='marka'>
                //            <p> Какая-то машинка  </p>
                //        </div>
                //        <p>5000 Руб./Сутки</p>"


                var cars = (new DBConnectionString()).Автомобиль.ToArray();
                int[] m_car = new int[cars.Count()];
                int count = 0;
                int max = 5;
                if (cars.Count() < 3)
                    max = cars.Count();

                while (count < max)
                {
                    Random ch = new Random();
                    int key = ch.Next(0, cars.Count());
                    if (m_car[key] != 1)
                    {
                        m_car[key] = 1;
                        count++;
                    }

                }
                int i = 0;
                foreach (var car in cars)
                {
                    if (m_car[i] == 1)
                    {
                        result += string.Format(
                           $@"<div class='col-lg-4'>
                            <img class='img-fluid' data-src='pic/pic4.jpg/140x140' alt='140x140' src='data:image/jpeg; base64,{car.Фото}' style='width: 140px; height: 140px;'>
                            <div class='marka'>
                                <p> { car.Модель.Марка } { car.Модель.Модель1 }</p>
                            </div> 
                            <p> {car.Стоимость} Руб./час</p>
                        </div>");

                    }
                    i++;
                }
                result += "</div></div>";
                //        < div class='col-lg-4'>
                //            <img class='img-fluid' data-src='pic/pic7.jpg/140x140' alt='200x200' src='pic/pic7.jpg' style='width: 300px; height: 200px;'>
                //            <div class='marka'>
                //                <p> Какая-то машинка</p>
                //            </div>
                //            <p> 10000 Руб./Сутки</p>
                //        </div>

                //        <div class='col-lg-4'>
                //            <img class='img-fluid' data-src='pic/pic8.jpg/140x140' alt='200x200' src='pic/pic8.jpg' style='width: 300px; height: 200px;'>
                //            <div class='marka'>
                //                <p> Какая-то машинка</p>
                //            </div>
                //            <p>13000 Руб./Сутки</p>
                //        </div>


                //        <!-- /.col-lg-4 -->
                //    </div><!-- /.row -->
                //</div>

                result += string.Format(
                   $@"<p><a class='btn btn-inverse btn-lg' onclick='showCars()' role='button'> Посмотреть все автомобили  →</a></p>
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
                                <p> ООО  'MEOWavto' является одной из крупнейших компаний Пермского края на рынке транспортных услуг.Начав свою деятельность в 2007 году, на сегодняшний день прочно удерживает лидирующие позиции, завоевав доверие многочисленных клиентов.  </p>
                                <p>

                                   Мы предлагаем Вам широкий спектр транспортных услуг: аренда автомобилей без водителя; аренда легковых автомобилей с водителем;
                                    аренда автомобиля на свадьбу;
                                    грузовые перевозки;
                                    пассажирские перевозки(аренда автобусов и микроавтобусов; трансфер(аэропорт 'Большое Савино', железнодорожный вокзал Пермь II);
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
                            <p>   по e-mail: meow @gmail.ru; </p>
                            <p>   по тел. 8 800 555 55 35;</p>
                        </div>
                        <div class='col-lg ml-auto'>
                            <img class='img-fluid' data-src='holder.js/140x140' alt='350x200' src='pic/cars.jpg' style='width: 450px; height: 300px;'>
                        </div>
                    </div>
                </div>


                <div class='footer'>
                    <p class='pull-right'><a>Вернуться наверх</a></p>
                    <p>© 2017 Company, Inc.MeowCat</p>
                </div>");
                return result;
            }
            if (id == "showLogin")
                return @"<div class='containerr'>   
           
                                 <h2> Вход </h2>
                                  <input id='tbLogin' type = 'login' class='form-control' placeholder='Логин' required='' autofocus=''>
                                  <input id='tbPassword' type = 'password' class='form-control' placeholder='Пароль' required=''>
                                <button class='btn btn-lg btn-primary btn-block' onclick='logInCl()'>Войти</button> 
                                <button class='btn btn-lg btn-primary btn-block' onclick='showReg()'>Регистрация</button>    
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
            if (id == "showReg")
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
                            <button class='btn btn-lg btn-primary btn-block' id = 'btnExit' onclick='showLogin()' > Войти в систему </ button >
                         </div>";






            if (id == "showCars")
            {
                const string quote = "\"";
                string result = @"
                                <div class='allcarsmenu'>
                <div class='col-lg-3'>
                <div class='filter'>
                <div class='namefil'><h4 class='form-check-label'>
                          <input type = 'checkbox'  id = 'sort' class='form-check-input'>
                      Сортировать по рейтингу
                    </h4></div>
                <div class='namefil'>
                    <h4 class='form-check-label'>
                        <input type = 'checkbox' id='dost' class='form-check-input'>
                        Показать только доступные для аренды
                    </h4>
                </div>
            
                <div class='namefil'><h4>Цена:</h4></div>
                <div class='col-xs-6'>
                    <label for='from'>MIN:</label>
                    <input class='form-control' id='minPrice' type='number' placeholder='' step='100' min='0'>
                </div>
                <div class='col-xs-6'>
                    <label for='from'>MAX:</label>
                    <input class='form-control' id='maxPrice' type='number' placeholder='' step='100' min='1000'>
                </div>

                <br> <br><br> <br>
                <button class=' btn btn-primary btn-lg btn-block' onclick='filterCars()'>Применить</button>
            </div>

        </div>
                                    <div class='col-lg-9'>
                <div id='allcars' class='allcarsmenu'>
                <table class='table table-striped '>
                    <thead>   
                        <tr>
                            <td>Фотография</td>
                            <td>Модель</td>
                            <td>Стоимость</td>
                            <td>Рейтинг</td>
                            <td>Доступность</td>
                            <td></td>
                            </tr>  
                    </thead>
                    <tbody>";
                var cars = (new DBConnectionString()).Автомобиль.ToArray();
                var zakaz = (new DBConnectionString()).Заказ.ToArray();
                var otziv = (new DBConnectionString()).Отзыв.ToArray();
                double summ = 0;
                int count = 0;
                foreach (var car in cars)
                {
                    var dostup = car.Доступность ? "Доступна" : "Недоступна";
                    result += string.Format(
                                            $@" <tr>
                         <td><img class='img-fluid' src='data:image/jpeg; base64,{car.Фото}' alt='200x200' style='width: 300px; height: 200px;'></td>
                         <td><div class='namecar'>{car.Модель.Марка} {car.Модель.Модель1}</div></td>
                         <td><div id = 'inStoim' class='pricecar'>{car.Стоимость} руб/час</div></td>");

                    summ = 0;
                    count = 0;
                    foreach (var zak in zakaz)
                    {
                        if (zak.idАвтомобиль == car.id)
                        {
                            foreach (var otz in otziv)
                            {
                                if (otz.id == zak.id)
                                {
                                    summ += otz.Рейтинг;
                                    count++;
                                }
                            }
                        }
                    }
                    if (count == 0)
                        summ = 0;
                    else
                        summ = summ / (double)count;

                    result += string.Format($@" <td>{summ}</td><td>{dostup}</td>
                         <td> <button type='button' class= 'btn btn-primary' onclick='showCar({quote + car.id + quote})'>Забронировать </button></td>
                         </tr>");
                }
                result += "</tbody></table></div></div>";
                return result;
            }

            if (id == "showCarsAdmin")
            {
                const string quote = "\"";
                string result = @"
                                <div class='allcarsmenu'>
                <div class='col-lg-3'>
                <div class='filter'>
                <div class='namefil'><h4 class='form-check-label'>
                          <input type = 'checkbox'  id = 'sort' class='form-check-input'>
                      Сортировать по рейтингу
                    </h4></div>
                <div class='namefil'>
                    <h4 class='form-check-label'>
                        <input type = 'checkbox' id='dost' class='form-check-input'>
                        Показать только доступные для аренды
                    </h4>
                </div>
              
                <div class='namefil'><h4>Цена:</h4></div>
                <div class='col-xs-6'>
                    <label for='from'>MIN:</label>
                    <input class='form-control' id='minPrice' type='number' placeholder='' step='100' min='0'>
                </div>
                <div class='col-xs-6'>
                    <label for='from'>MAX:</label>
                    <input class='form-control' id='maxPrice' type='number' placeholder='' step='100' min='1000'>
                </div>

                <br> <br><br> <br>
                <button class=' btn btn-primary btn-lg btn-block' onclick='filterCars()'>Применить</button>
            </div>

        </div>
                                    <div class='col-lg-9'>
                <div id='allcars' class='allcarsmenu'>
                <table class='table table-striped '>
                    <thead>
                        <tr>
                            <td>Фотография</td>
                            <td>Модель</td>
                            <td>Стоимость</td>
                            <td>Доступность</td>
                            <td>Владелец</td>
                            <td></td>

                    </tr>
                    </thead>
                    <tbody>";
                var cars = (new DBConnectionString()).Автомобиль.ToArray();
                foreach (var car in cars)
                {
                    var dostup = car.Доступность ? "Доступна" : "Недоступна";
                    result += string.Format(
                                            $@" 
                            <tr>
                         <td><img class='img-fluid' src='data:image/jpeg; base64,{car.Фото}' alt='200x200' style='width: 300px; height: 200px;'></td>
                         <td><div  class='namecar'>{car.Модель.Марка} {car.Модель.Модель1}</div></td>
                         <td><div  class='pricecar'>{car.Стоимость} руб/час</div></td>
                         <td>{dostup}</td>
                         <td>{car.Пользователь.Логин}</td>
                         <td> 
                            <button type = 'button' class= 'btn btn-primary' onclick='delCar({quote + car.id + quote}, {quote + false + quote})'>Удалить</button>
                             <a href = '#changAuto1' onclick='readCarSaveAdmin({quote + car.id + quote},{quote + car.Модель.Марка + quote},
                               {quote + car.Модель.Модель1 + quote},{quote + car.Описание + quote},{quote + car.Стоимость + quote})' 
                                type = 'button' class= 'btn btn-primary' data-toggle='modal' '>Редактировать</button></a> </td>  </tr>");
                }
                result += "</tbody></table></div></div>";
                result += @"<div id = 'changAuto1' class='modal fade'>
<div class='modal-dialog'>
            <div class='modal-content'>
                <div class='modal-header'>
                    <button type = 'button' class='close' data-dismiss='modal' aria-hidden='true'>×</button>
                    <h4 class='modal-title' >Изменение данных о автомобиле</h4>
                </div>


                <div class='modal-body'>
                <label > Марка: </label> <input id = 'inModel1' border = '0' type='label' disabled ></input >
                    <br>
                    <input id = 'carId1' hidden = ''>
                    <input id = 'inMod1' hidden = ''>
                    <input id = 'inMark1' hidden = ''>
                     ";

                result += $@"<br>
                        <label class> Описание: </label> <br>          
                    <textarea id = 'inOpis1' name = 'Descr' cols='50' rows='10'></textarea> <br>
                    <label> Стоимость: </label> <br>
                    <input id = 'inStoim1' type = 'text' name='price'>  <label> рублей\час </label><br>
                    <label> Фотография: </label> <br>
                    <input  type = 'file' name='photo' multiple accept = 'image/*,image/jpeg'> <br>
  
                  </div>
  
                  <div class='modal-footer'>
                    <button onclick='changAutoAdmin({quote + false + quote})' type = 'button' class='btn btn-primary' data-dismiss='modal' >Сохранить изменения</button>
                </div>
            </div>
        </div>";
                return result;
            }

            //if (id == "") {}

            return "";
        }


        public static string getStringVladelec(string id, Пользователь user)
        {
            if (id == "user")
            {
                string result = @"<div id='buttonlogin'><ul class='nav navbar-nav'>
                    <li>
                        <li class='dropdown'>
              <a class='dropdown-toggle' data-toggle='dropdown'>Мой аккаунт        <b class='caret'></b></a>
              <ul class='dropdown-menu'>
                 <li> <button onclick = 'showMenupolzSdan()' class='btn-link'>Мои автомобили</button></li>
                <li> <button onclick = 'showMenupolzZakaz()' class='btn-link'>Мои заказы</button></li>";

                if (user.Администратор == true)
                    result += @"<li> <button onclick = 'showCarsAdmin()' class='btn-link'>Все автомобили</button></li>
                <li> <button onclick = 'showMenuTablpolz()' class='btn-link'>Пользователи</button></li>";
                result += @"</ul>
                            </li></li><li>
                              <button onclick = 'exit()' class='btn-link btn-lg'>Выйти</button>
                        </li></div>";
                return result;
            }

            if (id == "menupolzSdan")
            {
                const string quote = "\"";
                string result = @"
<a href='#myModal' class='btn btn-primary' data-toggle='modal'>Добавить автомобиль</a>
    <div id = 'myModal' class='modal fade'>
            <div class='modal-dialog'>
                <div class='modal-content'>
                    <div class='modal-header'>
                        <button type = 'button' class='close' data-dismiss='modal' aria-hidden='true'>×</button>
                        <h4 class='modal-title' onclick='AddAuto()'>Добавить новый автомобиль</h4>
                    </div>


                <div class='modal-body'>
                <label> Марка:  </label>
                    <br>
                    <select class='selectpicker1' id = 'tbmodel'> ";
                var models = (new DBConnectionString()).Модель.ToArray();
                foreach (var mod in models)
                {
                    result += string.Format(
                        $@"<option>
                        {mod.Марка} {mod.Модель1} 
                         </option>");
                }
                result += @"</select><br>";
                result += @"<br>
                        <label class> Описание: </label> <br>          
                    <textarea id = 'tbOpis' name = 'Descr' cols='50' rows='10'></textarea> <br>
                    <label> Стоимость: </label> <br>
                    <input id = 'tbStoim' type = 'text' name='price'>  <label> рублей\час </label><br>
                    <label> Фотография: </label> <br>
                    <input id = 'tbFile' type = 'file' name='photo' multiple accept = 'image/*,image/jpeg'> <br>
  
                  </div>
  
                  <div class='modal-footer'>
                    <button onclick='addAuto()' type = 'button' class='btn btn-primary' data-dismiss='modal' >Добавить</button>
                </div>
            </div>
        </div>
</div>
                              <div class='allcars'>
                                <table class='table table-bordered table-hover'>
                            <thead>
                             <tr>
                             <th>Фотография</th>
                             <th>Модель</th>
                             <th>Стоиомость</th>
                             <th>Рейтинг</th>
                             <th>Описание</th>
                             <th></th>
                             </tr>
                             </thead>
                             <tbody> ";
                var cars = (new DBConnectionString()).Автомобиль.ToArray();
                var reiting = (new DBConnectionString()).Отзыв.ToArray();
                double summ;
                int count;
                foreach (var car in cars)
                {
                    if (car.idВладелец == user.id)
                    {
                        result += string.Format(
                            $@"<tr>
                         <td><img class='img-fluid' src='data:image/jpeg; base64,{car.Фото}' alt='200x200' style='width: 300px; height: 200px;'></td>
                         <td>{car.Модель.Марка} {car.Модель.Модель1}</td>
                         <td>{car.Стоимость} руб/час</td>");
                        summ = 0;
                        count = 0;
                        foreach (var reit in reiting)
                        {
                            if (reit.Заказ.idАвтомобиль == car.id)
                            {
                                summ = summ + reit.Рейтинг;
                                count++;
                            }
                        }
                        if (count != 0)
                            summ = summ / count;
                        var dostup = car.Доступность ? "Свободна" : "Занято";
                        result += string.Format($@"<td>{summ}</td> 
                         <td>{car.Описание}</td> 
                         <td><button type = 'button' class= 'btn btn-primary' onclick='delCar({quote + car.id + quote}, {quote + true + quote})'>Удалить</button>
                             <a href = '#changAuto' onclick='readCarSave({quote + car.id + quote},{quote + car.Модель.Марка + quote},{quote + car.Модель.Модель1 + quote},{quote + car.Описание + quote},{quote + car.Стоимость + quote})' type = 'button' class= 'btn btn-primary' data-toggle='modal' '>Редактировать</button></a> </tr> "
                    );
                    }
                }
                result += $@"</tbody></table></div>
<div id='changAuto' class='modal fade'>
<div class='modal-dialog'>
            <div class='modal-content'>
                <div class='modal-header'>
                    <button type = 'button' class='close' data-dismiss='modal' aria-hidden='true'>×</button>
                    <h4 class='modal-title' >Изменение данных о автомобиле</h4>
                </div>


                <div class='modal-body'>
                <label > Марка: </label> <input  id = 'inModel' border = '0' type='label' disabled ></input >
                    <br>
                    <input id = 'carId' hidden = ''>
                    <input id = 'inMod' hidden = ''>
                    <input id = 'inMark' hidden = ''>
                     ";



                result += $@"<br>
                        <label class> Описание: </label> <br>          
                    <textarea id = 'inOpis' name = 'Descr' cols='50' rows='10'></textarea> <br>
                    <label> Стоимость: </label> <br>
                    <input id = 'inStoim' type = 'text' name='price'>  <label> рублей\час </label><br>
                    <label> Фотография: </label> <br>
                    <input  type = 'file' name='photo' multiple accept = 'image/*,image/jpeg'> <br>
  
                  </div>
  
                  <div class='modal-footer'>
                    <button onclick='changAuto({quote + true + quote})' type = 'button' class='btn btn-primary' data-dismiss='modal' >Сохранить изменения</button>
                </div>
            </div>
        </div>";

                return result;
            }

            if (id == "menupolzZakaz")
            {
                const string quote = "\"";
                string result = @"
                              <div class='allcars'>
                                <table class='table table-bordered table-hover'>
                            <thead>
                             <tr>
                             <th>Фотография</th>
                             <th>Модель</th>
                             <th>Стоимость</th>
                             <th>Дата начала заказа</th>
                             <th>Количество времени, час.</th>
                             <th>Итоговая сумма</th>
                             <th></th>
                             </tr>
                             </thead>
                             <tbody> ";
                var cars = (new DBConnectionString()).Автомобиль.ToArray();
                var reiting = (new DBConnectionString()).Отзыв.ToArray();
                var zakaz = (new DBConnectionString()).Заказ.ToArray();
                var connection = new DBConnectionString();
                bool flag = true;
                string text = "";
                foreach (var zak in zakaz)
                {
                    if (zak.idПользователь == user.id)
                    {
                        result += string.Format(
                            $@"<tr>
                         <td><img class='img-fluid' src='data:image/jpeg; base64,{zak.Автомобиль.Фото}' alt='200x200' style='width: 300px; height: 200px;'></td>
                         <td>{zak.Автомобиль.Модель.Марка} {zak.Автомобиль.Модель.Модель1}</td>
                         <td>{zak.Автомобиль.Стоимость} руб/час</td>
                         <td>{zak.ДатаВремяНачалаАредны} </td>
                         <td>{((zak.ДатаВремяКонцаАренды - zak.ДатаВремяНачалаАредны).Hours)} </td>
                         <td>{((zak.ДатаВремяКонцаАренды - zak.ДатаВремяНачалаАредны).Hours) * zak.Автомобиль.Стоимость} </td>
                          ");
                        foreach (var car in cars)
                        {

                            if (car.id == zak.idАвтомобиль)
                            {
                                foreach (var reit in reiting)
                                {
                                    if (reit.idЗаказ == zak.id)
                                    {
                                        flag = false;
                                        text = @"Вы оценили услугу в " + reit.Рейтинг + " из 5 баллов <br> И оставили свой отзыв : <br>" + reit.Текст;
                                    }
                                }
                            }

                        }
                        if (flag)
                            result += string.Format($@"<td><a href='#review' onclick = 'Otziv({quote + zak.Автомобиль.id + quote},{quote + zak.id + quote} )' class='btn btn-primary' data-toggle='modal'>Оставить отзыв</a> </td></tr>");
                        else
                            result += string.Format($@"<td>{text}</td></tr> ");
                        flag = true;
                    }
                }
                result += $@"</tbody></table></div>
<div id='review' class='modal fade'>
  <div class='modal-dialog'>
    <div class='modal-content'>
      <div class='modal-header'>
        <button type = 'button' class='close' data-dismiss='modal' aria-hidden='true'>×</button>
        <h4 class='modal-title'>Отзыв</h4>
      </div>
    
    
                    <div class='modal-body'>
                        <input id = 'ratings-hidden' name='rating' type='hidden'> 
                        <textarea id = 'tbText' class='form-control animated' cols='50' id='new-review' name='comment' placeholder='Оставьте здесь свой отзыв...' rows='5'></textarea>
                        <br><input id = 'idAuto' hidden = ''><input id = 'idZak' hidden = ''>
                        <br><label> Оцените арендованный автомобиль</label> 
                        <br><select id = 'tbrait'>  
                        <option>1</option>
                        <option>2</option>
                        <option>3</option>
                        <option>4</option>
                        <option>5</option>
                    </select> <label> Балл </label>
                      </div>
      <div class= 'modal-footer'>
        <button id='savereview' onclick = 'saveOtziv( $({quote}#idAuto{quote}).text(),$({quote}#idZak{quote}).text() )'  type = 'button' class='btn btn-primary' data-dismiss='modal'>Сохранить отзыв</button>
      </div>

</div></div></div>";

                return result;
            }
            return "";
        }

        public static string getStringWithId(string id, string strGuid)
        {
            if (id == "showCar" && strGuid != null)
            {
                var guid = new Guid(strGuid);
                var car = new DBConnectionString().Автомобиль.FirstOrDefault(x => x.id == guid);
                const string quote = "\"";
                if (car != null)
                {
                    return $@"
<div class='car'>
        <h1>{car.Модель.Марка} {car.Модель.Модель1}</h1>
        <br>
        <div class='row'>
            <div class='col-lg-6 ml-auto'>
                <img class='img-rounded' src='data:image/jpeg; base64,{car.Фото}' alt='350x200' style='width: 450px; height: 300px;'>
                <div class='rating'>
                    <p>Рейтинг:</p>
                    <div class='stars starrr' data-rating='5' enabled='false' readonly='true'></div>
                </div>
                <div class='price'>
                    <p> Цена за день: </p>
                    <p> {car.Стоимость} руб./день </p>
                </div>
            </div>

            <div class='col-lg-5 ml-auto'>
                <p>
                    {car.Описание}
                </p>
                <br>

                <div class='order'>
                    <label>Дата и время начала: </label>
                    <div class='input-group' id='datetimepicker2'>
                        <input type='text' class='form-control'>
                        <span class='input-group-addon'>
                            <span class='glyphicon glyphicon-calendar'></span>
                        </span>
                    </div>
                    <br>
                    <label>Количество часов: </label>
                    <select id='hourSelector' class='selectpicker'>

                        <option>1</option>
                        <option>2</option>
                        <option>3</option>
                        <option>4</option>
                        <option>5</option>
                        <option>6</option>
                        <option>7</option>
                        <option>8</option>
                        <option>9</option>
                        <option>10</option>
                        <option>11</option>
                        <option>12</option>
                        <option>13</option>
                        <option>14</option>
                        <option>15</option>
                        <option>16</option>
                        <option>17</option>
                        <option>18</option>
                        <option>19</option>
                        <option>20</option>
                    </select>

                    <br> <br>
                    <button class='btn btn-lg btn-primary' id='btnreg' onclick='rentCar({quote + car.id + quote})'> Забронировать </button>
                    <button class='btn btn-lg btn-primary' id='btnback' onclick=''> Назад </button>
                </div>
            </div>
        </div>


    </div>";







                }
            }
            return "";
        }

        public class MyClass
        {
            public Guid MyGu { get; set; }
            public Double MyD { get; set; }
        }


        public static string GetFilteredString(string tag, string dostupnost, string reiting, int? min, int? max)
        {
            const string quote = "\"";
            string result = @"
                <table class='table table-striped '>
                    <thead>
                        <td>Фотография</td>
                            <td>Модель</td>
                            <td>Стоимость</td>
                            <td>Рейтинг</td>
                            <td>Доступность</td>
                            <td></td>
                    </thead>
                    <tbody>";
            var cars = (new DBConnectionString()).Автомобиль.ToArray();
            var zakaz = (new DBConnectionString()).Заказ.ToArray();
            var otziv = (new DBConnectionString()).Отзыв.ToArray();
            var list = new List<MyClass>();
            var list2 = new List<MyClass>();
            if (dostupnost == "True")
            {
                cars = cars.Where(x => x.Доступность).ToArray();
            }
            if (true)
            {
                foreach (var carr in cars)
                {
                    double summ = 0;
                    int count = 0;
                    foreach (var zak in zakaz)
                    {
                        if (zak.idАвтомобиль == carr.id)
                        {
                            foreach (var otz in otziv)
                            {
                                if (otz.id == zak.id)
                                {
                                    summ += otz.Рейтинг;
                                    count++;
                                }
                            }
                        }
                    }
                    if (count == 0)
                        list.Add(new MyClass { MyGu = carr.id, MyD = 0 });
                    else
                        list.Add(new MyClass { MyGu = carr.id, MyD = summ / (double)count });
                }

                list2 = list.OrderBy(x => x.MyD).ThenBy(x => x.MyGu).ToList();

            }
            if (min != null)
            {
                cars = cars.Where(x => x.Стоимость >= min).ToArray();
            }
            if (max != null)
            {
                cars = cars.Where(x => x.Стоимость <= max).ToArray();
            }

            if (reiting == "True")
            {
                for (int j = list2.Count() - 1; j >= 0; j--)
                {
                    foreach (var car in cars)
                    {
                        if (car.id == list2[j].MyGu)
                        {
                            var dostup = car.Доступность ? "Доступна" : "Недоступна";
                            result += string.Format(
                                            $@" <tr>
                         <td><img class='img-fluid' src='data:image/jpeg; base64,{car.Фото}' alt='200x200' style='width: 300px; height: 200px;'></td>
                         <td><div class='namecar'>{car.Модель.Марка} {car.Модель.Модель1}</div></td>
                         <td><div class='pricecar'>{car.Стоимость} руб/час</div></td>
                         <td>{list2[j].MyD}</td>
                         <td>{dostup}</td>
                         <td> <button type='button' class= 'btn btn-primary' onclick='showCar({quote + car.id + quote})'>Забронировать </button></td>
                         </tr>");
                        }
                    }


                }
            }

            else
            {
                foreach (var car in cars)
                {
                    for (int j = list2.Count() - 1; j >= 0; j--)
                    {
                        if(car.id == list2[j].MyGu)
                        {
                            var dostup = car.Доступность ? "Доступна" : "Недоступна";
                            result += string.Format(
                                            $@" <tr>
                         <td><img class='img-fluid' src='data:image/jpeg; base64,{car.Фото}' alt='200x200' style='width: 300px; height: 200px;'></td>
                         <td><div class='namecar'>{car.Модель.Марка} {car.Модель.Модель1}</div></td>
                         <td><div class='pricecar'>{car.Стоимость} руб/час</div></td>
                        <td>{list2[j].MyD}</td>
                         <td>{dostup}</td>
                         <td> <button type='button' class= 'btn btn-primary' onclick='showCar({quote + car.id + quote})'>Забронировать </button></td>
                         </tr>");
                        }
                    }
                }






            }
            result += "</tbody></table>";
            return result;
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