<<<<<<< HEAD
select B.Product, r.ExpCus, r.ExpDes, r.ExpDate, r.ExpEmp, u.Email, u.PhoneNumber
from AspNetUsers U, ExpBillDetails B, ExportBills R 
where r.ExpEmpId = u.Id
=======
>>>>>>> 8f17def5c96aab88904bee9f3b3ad079c94f8bde
