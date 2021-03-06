## Инфо

TimeWorkTracking простое клиент серверное приложение контроля и учета рабочего времени сотрудников (вход выход)  
Ручная регистрация + данные СКУД [Proxway](https://proxway-ble.ru/zagruzki/programmnoe-obespechenie/web-interfejs-proxway-web) + Печать бланков + Выпуск итогового отчета руководству.  


![image](https://user-images.githubusercontent.com/16114000/145944135-25292474-79eb-423d-9efd-29f34738c6cb.png)


```bash
изначально использовалась база на Excel c 2007 года,
(https://github.com/AlexandreZaytsev/restAPI-ProxWay-PACS)
но с количеством записей > ~100000 стала тормозить и... 
была перезаписана в классическом клиент серверном варианте
```
* * *
### Характеристики
* Учетные записи: Администратор (пароль), Регистратор (без пароля)  
* Справочник сотрудников компании (график работы, отдел, должность и т.д.)  
* Справочник специальных отметок (аналогично [Т12](http://www.consultant.ru/document/cons_doc_LAW_47274/05305f7475e7ec92c38eb6e6e6b4ff56c94cd475/) и т.д.)   
* Справочник Производственный календарь (из открытых источников [например](http://www.consultant.ru/law/ref/calendar/proizvodstvennye/2022/))
* Подготовка Бланков проходов и Контроля температуры (за период) (для проходной)
* Выпуск итогового отчета по проходам (аналогично [Т13](http://www.consultant.ru/document/cons_doc_LAW_47274/cb2decd42a1e8f0132773a25e85e40f84ce78f9e/) и т.д.) 
* Импорт Экспорт данных (BackUp) в Excel

### Системные требования

* Windows   
* .NET Framework 3.5 и выше   
* MS SQL Server 2005 и выше (Express, Standard ... )   
* MS Excel 2010 и выше   

*минимальные требования по софту специально занижены до версий (уже снятых microsoft с поддержки) обычно используемых в повседневной работе*

### Развертывание
```bash
доступ к сетевой MSSQL базе данных (можете локально развернуть бесплатный MSSQL Express)
 -можете использовать MSSQL Express 2014 из поставки ProxWay
доступ к облачному сервису СКУД (в данном случае ProxWay https://proxway-ble.ru/
```
* запустите программу  
* настройте подключение к MSSQL и здесь же создайте базу данных (с любым именем)   
*будет создана пустая БД с настроенными таблицами хранимыми процедурами (sp) и пользовательскими функциями (udf)(рекомендуется первый раз задействовать загрузку с минимальными данными справочников (здесь же))*   
* настройте подключение к сервису [СКУД](https://proxway-ble.ru/zagruzki/programmnoe-obespechenie/web-interfejs-proxway-web) (можно работать и без него)

## ПРОГРАММА ГОТОВА К РАБОТЕ!!!  
```bash
всего один файл - TimeWorkTracking.exe, без дополнительных *.dll (не считая системного framework) 
```
в дальнейшем
* заполните справочник сотрудников (есть управление доступностью к использованию)
* заполните производственный календарь (на интересующий вас год/года)
* если есть  накопленные данные в виде упорядоченных строк/колонок - можете произвести первоначальное наполнение системы своими данными через импорт
* для перехода с сервера на сервер используйте стандартные бекапы MSSQL (снизу вверх) или данные экспорта рабочей системы
*имейте ввиду - основные таблицы связаны между собой и при работе с ними по отдельности (очистка перезаливка) могут возникнуть ошибки (система вас не пропустит)*

### Порядок работы
* распечатать бланк проходов (+ бланк учета температуры) на предстоящую неделю  
* в конце недели - по данному (уже заполненному) бланку - зарегистрировать данные в системе
*при регистрации вам предлагается время из рабочего графика сотрудника + время отмеченное в бланке регистрации + время первого последнего прохода в СКУД*
* в конце месяца выпустите итоговый отчет

* * *
фичи
* если вы забыли админский пароль - можно сбросить его из командной строки (см. диалог About)
* красиво получился компонент производственного календаря! загрузка в каледарь на форме всех праздников и их переносов, включая нерабочие дни и отображение информации о них в HTML формате
* при использовании [мультиформатных считывателей](https://proxway-ble.ru/oborudovanie/schityvateli/mifare/pw-mini-multi-ble) можете запускать сотрудников по мобильным меткам (Android IOS), обычным картам доступа Marine Mifare, пропускам в бассейн, банковским картам и проездным картам ТРОЙКА!!! (до сих пор тащимся)    
* * *
![image](https://user-images.githubusercontent.com/16114000/145944184-9c648405-451f-4c5d-a4d9-cc8059a75f93.png)
![image](https://user-images.githubusercontent.com/16114000/145951718-5fdef3aa-9bb0-4d52-8fbb-18cd7c1800a7.png)
![image](https://user-images.githubusercontent.com/16114000/146530181-d29c9482-1be1-4ebf-9dd3-7b54bf362694.png)
![image](https://user-images.githubusercontent.com/16114000/146750359-6fb0fdbf-2123-4e3d-8598-1e45acdd6eba.png)



