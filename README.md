## Инфо

TimeWorkTracking простое клиент серверное приложение контроля и учета рабочего времени сотрудников (вход выход)  
Ручная регистрация + данные СКУД Proxway + Печать бланков + Выпуск итогового отчета руководству.  


![image](https://user-images.githubusercontent.com/16114000/145944135-25292474-79eb-423d-9efd-29f34738c6cb.png)


```bash
изначально использовалась база на Excel c 2007 года,
но с количеством записей > ~100000 стала тормозить и была перезаписана в классическом клиент серверном варианте
```
* * *
### Характеристики
* Учетные записи: Администратора (пароль), Регистратора (без пароля)  
* Справочник сотрудников компании (график работы, отдел, должность и т.д.)  
* Справочник специальных отметок (аналогично Т12 и т.д.)   
* Справочник Производственный календарь (из открытых источников например консультант плюс)
* Подготовка Бланков проходов и Контроля температуры (за период) (для проходной)
* Выпуск итогового отчета по проходам (аналогично Т13 и т.д.) 
* Импорт Экспорт данных (BackUp) в Excel

### Системные требования

* Windows   
* .NET Framework 3.5   
* MS SQL Server 2005 и выше (Express, Standard ... )   
* MS Excel 2010 и выше   

*минимальные требования по софту специально занижены до версий (уже снятых microsoft с поддержки) обычно используемых в повседневной работе*

### Развертывание
```bash
доступ к сетевой MSSQL базе данных (можете локально развернуть бесплатный MSSQL Express)
доступ к облачному сервису СКУД (в данном случае ProxWay https://proxway-ble.ru/
```
* запустите программу  
* настройте подключение к MSSQL и здесь же создайте базу данных (с любым именеи)   
*будет создана пустая БД с настроенными таблицами хранимыми процедурами (sp) и пользовательскими функциями (udf)(рекомендуется первый раз задействовать загрузку с минимальными данными справочников (здесь же))*   
* настройте подключение с сервису [СКУД](https://proxway-ble.ru/zagruzki/programmnoe-obespechenie/web-interfejs-proxway-web) (можно работатьи без него)

ПРОГРАММА ГОТОВА К РАБОТЕ!!!

в дальнейшем
* заполните справочник сотрудников (есть управление доступностью к использованию)
* заполните производственный календарь (на интересующий вас год)
* если есть  накопленные данные в виду упорядоченных строк/колонок - можете произвести первоначальное наполнение системы своими данными
* для перехода с сервера на сервер используйте стандартные бекапы MSSQL (снизу вверх) или данные экспорта рабочей системы
*имейте ввиду основные таблицы связаны между собой и при работе с ними по отдельности (очиста перезаливка) могут возникнуть ошибки (система вас не пропустит)*

### Порядок работы
* распечатать бланк проходов (+ бланк учета темперватуры) на предстоящую неделю  
* в конце недели - по данному (уже заполненному) бланку - зарегистировать данные в системе
*при регистрации вам предлагается время из рабочего графика сотрудника + время отмеченное в бланке регистрации + двремя первого последнего прохода в СКУД*
* в конце месяца выпустите итоговый отчет

* * *
фичи
* если вы забыли админский пароль - можно сбросить его из командной строки (см. диалог About)
* красиво получился компонент производственного календаря! загрузка в каледарь на форме всех праздников и их переносов, включая нерабочие дни и отображение информации в HTML формате
* при использованиих [мультиформатных считывателей](https://proxway-ble.ru/oborudovanie/schityvateli/mifare/pw-mini-multi-ble) можете запускать сотрудников по мобильным меткам (Android IOS), обычным картам доступа, пропускам в бассейн и картам ТРОЙКА!!! (до сих пор тащимся)    
* * *
![image](https://user-images.githubusercontent.com/16114000/145944184-9c648405-451f-4c5d-a4d9-cc8059a75f93.png)
![image](https://user-images.githubusercontent.com/16114000/145951140-8ee5985e-de00-47b3-a85b-e89476cda3f0.png)
