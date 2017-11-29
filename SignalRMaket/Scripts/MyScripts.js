﻿var myHub;
function Initialize() {  
    myHub = $.connection.myHub;
    myHub.client.alertFuncCl = function (mes) { alert(mes) };
    myHub.client.onSuccessfulLoginCl = onSuccessfulLoginImpl;
    myHub.client.showMenupolzSdan = function () { showMenupolzSdan() };
    myHub.client.showMenupolzZakaz = function () { showMenupolzZakaz() };
    myHub.client.showMenuTablpolz = function () { showMenuTablpolz() };
    myHub.client.showMenuAllAuto = function () { showMenuAllAuto() };
    myHub.client.showCarsAdmin = function () { showCarsAdmin() };
    $.connection.hub.start().done(hubStarted).done(function () {
        myHub.server.getHtmlSv('menu').done(function (html) {
            replaceHtml('main', html);
        });
    });
}

function hubStarted() {
   
}


function replaceHtml(id, html) {
	$('#' + id).empty().append(html);
}
//Авторизация пользователя
function logInCl() {
	myHub.server.logInSv($('#tbLogin').val(), $('#tbPassword').val());
}
//Показать страницу регистрации
function Registr() {
    myHub.server.getHtmlSv('reg').done(function (html) {
    replaceHtml('main', html);
    });
}
//Показать страницу авторизации
function showLogin() {
    myHub.server.getHtmlSv('showLogin').done(function (html) {
        replaceHtml('main', html);
    });
}
//Показать страницу всех авто
function showCars() {
    myHub.server.getHtmlSv('showCars').done(function (html) {
        replaceHtml('main', html);
    });
}
//Показать страницу всех авто(для админа)
function showCarsAdmin() {
    myHub.server.getHtmlSv('showCarsAdmin').done(function (html) {
        replaceHtml('main', html);
    });
}
//Замена кнопки входа на личный аккаунт пользователя
function onSuccessfulLoginImpl() {

    myHub.server.getHtmlSvPolz('user').done(function (html) {
        replaceHtml('buttonlogin', html);
    });

	myHub.server.getHtmlSv('menu').done(function (html) {
        replaceHtml('main', html);
    });
 
}
//Показать главную страницу
function showMain() {
    myHub.server.getHtmlSv('menu').done(function (html) {
        replaceHtml('main', html);
    });
}
//Показать страницу , авто сдающихся в аренду
function showMenupolzSdan() {
    myHub.server.getHtmlSvPolz('menupolzSdan').done(function (html) {
        replaceHtml('main', html);
    });
}
//Показать страницу "Все авто"
function showMenuAllAuto() {
    myHub.server.getHtmlSv('showCars').done(function (html) {
        replaceHtml('main', html);
    });
}
//Показать страницу историю аренды пользователя
function showMenupolzZakaz() {
    myHub.server.getHtmlSvPolz('menupolzZakaz').done(function (html) {
        replaceHtml('main', html);
    });
}
//Показать страницу всех пользователей(для админа)
function showMenuTablpolz() {
    myHub.server.getHtmlSv('menuTablpolz').done(function (html) {
        replaceHtml('main', html);
    });
}
//Добавление авто для аренды
function addAuto() {
    //base64($("#tbFile"), function (data) {
    //    console.log(data.base64)
    //})
    //var fileData;
    //createImageBitmap($("#tbFile").prop("files")[0]).then(function (response) {
    //    fileData = response });
    

    //url = URL.createObjectURL($("#tbFile").prop("files")[0])
    //var xhr = new XMLHttpRequest;
    //xhr.responseType = 'blob';

    //xhr.onload = function () {
    //    var recoveredBlob = xhr.response;

    //    var reader = new FileReader;

    //    reader.onload = function () {
    //        var blobAsDataUrl = reader.result;
    //        window.location = blobAsDataUrl;
    //    };

    //    reader.readAsDataURL(recoveredBlob);
    //};

    //xhr.open('GET', url);
    //xhr.send();
    createImageBitmap($("#tbFile").prop("files")[0]).then(function (response) {
        var canvas = document.createElement("canvas")
        canvas.width = response.width;
        canvas.height = response.height;
        var context = canvas.getContext("2d")
        context.drawImage(response, 0, 0) // i assume that img.src is your blob url
        var dataurl = canvas.toDataURL('image/jpeg', 0.1);

        myHub.server.addAutoSv($('#tbmodel').val(), $('#tbOpis').val(), $('#tbStoim').val(), dataurl);
    });
}
//Показать информацию о фирме
function showOnas() {
    myHub.server.getHtmlSv('Onas').done(function (html) {
        replaceHtml('main', html);
    });
}
//Показать контакты фирмы
function showContact() {
    myHub.server.getHtmlSv('contact').done(function (html) {
        replaceHtml('main', html);
    });
}
//Показать страницу регистрации
function showReg() {
    myHub.server.getHtmlSv('showReg').done(function (html) {
        replaceHtml('main', html);
    });
}

function changeContent(htmlTag) {
	myHub.server.getHtmlSv(htmlTag).done(function (html) {
		replaceHtml('cont', html);
	});
}
//Регистрация
function reg() {
    myHub.server.registr($('#tbLogin').val(), $('#tbPassword').val(), $('#tbName').val(), $('#tbFname').val(), $('#tbOname').val());
}
//Выход из аккаунта
function exit() {
    location.reload(true);
}
//Аренда автомобиля
function rentCar(carId) {
  myHub.server.rentCar(carId, $('#hourSelector').val());
}
//Удаление авто
function delCar(carId, typ) {
    myHub.server.deltCar(carId, typ);
}
//Удаление пользователя админом
function delPolz(userId) {
    myHub.server.deltPolz(userId);
}
//Передача данных на модальное окно отзыва
function Otziv(carId, zakId) {
    $('#idAuto').text(carId);
    $('#idZak').text(zakId);
}
//Передача данных на модальное окно изменения профиля пользователя
function Profil(userId, userLogin, userName, userFname, userOname, userStatus)
{
    document.getElementById('Userid').value = userId;
    document.getElementById('inLogin').value = userLogin;
    document.getElementById('inPassword').value = "";
    document.getElementById('inName').value = userName;
    document.getElementById('inFname').value = userFname;
    document.getElementById('inOname').value = userOname;
    if (userStatus == "True")
        document.getElementById('inStatus').value = "Администратор";
    else
        document.getElementById('inStatus').value = "Пользователь"; 
}

//Передача данных на модальное окно изменения информации авто
function readCarSave(carId, model, marka, opis, stoim)
{
    document.getElementById('carId').value = carId;
    document.getElementById('inModel').value = model + " " + marka;
    document.getElementById('inMod').value = model;
    document.getElementById('inMark').value = marka;
    document.getElementById('inOpis').value = opis;
    document.getElementById('inStoim').value = stoim;
    //document.getElementById('inFile').value = file;
}

//Передача данных на модальное окно изменения информации авто
function readCarSaveAdmin(carId, model, marka, opis, stoim) {
    document.getElementById('carId1').value = carId;
    document.getElementById('inModel1').value = model + " " + marka;
    document.getElementById('inMod1').value = model;
    document.getElementById('inMark1').value = marka;
    document.getElementById('inOpis1').value = opis;
    document.getElementById('inStoim1').value = stoim;
    //document.getElementById('inFile').value = file;
}
//Сохранение изменений профиля
function saveProfil() {
    myHub.server.sVP(
        $('#Userid').val(),
        $('#inLogin').val(),
        $('#inPassword').val(),
        $('#inName').val(),
        $('#inFname').val(),
        $('#inOname').val(),
        $('#inStatus').val() );
}
//Сохранение изменений об авто
function changAutoAdmin(typ) {
    myHub.server.cngAuto(
        $('#carId1').val(),
        $('#inMod1').val(),
        $('#inMark1').val(),
        $('#inOpis1').val(),
        $('#inStoim1').val(),
        $('#inFile1').val(), typ);
}
  //Сохранение изменений об авто
function changAuto(typ) {
    //myHub.server.cngAuto(
    //    $('#carId').val(),
    //    $('#inMod').val(),
    //    $('#inMark').val(),
    //    $('#inOpis').val(),
    //    $('#inStoim').val(),
    //    $('#inFile').val(), );

    createImageBitmap($("#inFile").prop("files")[0]).then(function (response) {
        var canvas = document.createElement("canvas")
        canvas.width = response.width;
        canvas.height = response.height;
        var context = canvas.getContext("2d")
        context.drawImage(response, 0, 0) // i assume that img.src is your blob url
        var dataurl = canvas.toDataURL('image/jpeg', 0.1);

        myHub.server.cngAuto($('#carId').val(), $('#inMod').val(), $('#inMark').val(), $('#inOpis').val(), $('#inStoim').val(), dataurl, typ);
    });
}
//Сохранение отзыва об авто
function saveOtziv(carId , zakId) {
    myHub.server.saveOtziv(carId, zakId, $('#tbrait').val(), $('#tbText').val());
}
    
//Показать страницу подробной информации о автомобиле
function showCar(carId) {
    myHub.server.getHtmlWithIdSv('showCar',carId).done(function (html) {
        replaceHtml('main', html);
    });

}
//Приминение фильтров на странице с автомобилями
function filterCars() {
    myHub.server.getHtmlFilterCars('', $('#dost').is(':checked'), $('#sort').is(':checked'), $('#minPrice').val(), $('#maxPrice').val()).done(function (html) {
        replaceHtml('allcars', html);
    });
}

function changeStyle() {    
    if ($('#styleLink').attr('href') === 'css/style.css')
        $('#styleLink').attr('href', 'css/stylenew.css');
    else
        $('#styleLink').attr('href', 'css/style.css');
}

//for sending pictures
//$(document).ready(function () {
//    $('#tbFile').change(function () {

//        readURL(this);

//    });

//});
//function readURL(input) {
//    if (input.files && input.files[0]) {
//        var reader = new FileReader();
//        reader.onload = function (e) {

//            $('#imagePreview').attr('src', e.target.result);
//        }

//        reader.readAsDataURL(input.files[0]);
//    }
//}

//function saveimage() {
//    var images = $('#tbFile').attr('src');
//    var ImageSave = images.replace("data:image/jpeg;base64,", "");
//    var submitval = JSON.stringify({ data: ImageSave });

//    $.ajax({
//        type: "POST",
//        contentType: "application/json;charset=utf-8",
//        datatype: "json",
//        data: submitval,
//        url: "your url",
//        success: function (data) {
//            //code for success
//        }
//    });
//}

function base64(file, callback) {
    var coolFile = {};
    function readerOnload(e) {
        var base64 = btoa(e.target.result);
        coolFile.base64 = base64;
        callback(coolFile)
    };

    var reader = new FileReader();
    reader.onload = readerOnload;

    var file = file[0].files[0];
    coolFile.filetype = file.type;
    coolFile.size = file.size;
    coolFile.filename = file.name;
    reader.readAsBinaryString(file);
}