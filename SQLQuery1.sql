select B.Product, r.ExpCus, r.ExpDes, r.ExpDate, r.ExpEmp, u.Email, u.PhoneNumber
from AspNetUsers U, ExpBillDetails B, ExportBills R 
where r.ExpEmpId = u.Id