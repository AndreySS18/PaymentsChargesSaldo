В данной работе создан простой интерфейс для работы с Базой данных и несколькими табличками по средствам
Razor Pages (ASP.NET Core), Dapper и MySql Workbench. 

Ниже представлена Домашняя страница (/HomePage)
![image](https://github.com/AndreySS18/PaymentsChargesSaldo/assets/102410186/06b96d5a-b722-4642-bd43-c07ee55888fa)
Перед пользователем выводятся 2 таблички с начислениями и платежами, которые содержатся в БД
При нажатии на кнопки New Charges / New Payment пользователю предлагается заполнить все поля и внести информацию о Новом Платеже / Поступлении в БД.
![image](https://github.com/AndreySS18/PaymentsChargesSaldo/assets/102410186/a009a878-c2f8-4358-93d5-1c96d1ef9bb7)
![image](https://github.com/AndreySS18/PaymentsChargesSaldo/assets/102410186/faaee324-ae3f-49fe-a004-d6842d86685e)
Также при нажатии на кнопку Delete - информация о Платеже / Начилении просто удаляется из БД, а также соответсвенно 
данная строчка исчезает из таблиц на Главной странице.
Удаление 2 платежей
![image](https://github.com/AndreySS18/PaymentsChargesSaldo/assets/102410186/e1afe9cc-0c87-4543-a4fa-866ae866bea1)
Также имеется возможность изменить текущие Платежи или Начисления - с помощью кнопки Edit, при нажатии на неё перед пользователем открывается
страница с интерфейсом схожим при добавлении, но с изменением того, что все поля являются заполнеными теми значениями, которые принадлежат данной квартире
![image](https://github.com/AndreySS18/PaymentsChargesSaldo/assets/102410186/86547c8a-e3a0-4ae2-8d77-3c798e9af16f)
После изменений пользователь может нажать кнопку Submit - и тогда информация обновится в БД или отменить операцию, нажав Cancel - тогда изменения внесены не будут
Также имеется страница Search, где пользователь может Найти Сальдо, по интересующей его квартире, есть в БД есть информация о поступлениях и платежах об этой квартире, при
отсутсвии одного из параметров пользователю выдаст ошибку
![image](https://github.com/AndreySS18/PaymentsChargesSaldo/assets/102410186/21378cab-46fd-4015-8915-2fded7b11c28)
![image](https://github.com/AndreySS18/PaymentsChargesSaldo/assets/102410186/48b5dc51-a00a-43f2-8969-1b85c4c02e80)
