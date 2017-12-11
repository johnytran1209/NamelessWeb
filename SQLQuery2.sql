select B.Product, U.FullName, u.Email,U.Address, u.PhoneNumber, r.ExpDate, r.ExpDes 
from Guitars G, AspNetUsers U, ExpBillDetails B, ExportBills R 
where R.ExpCusId= u.Id and r.ExpEmpId = u.Id


select a.FullName,
       b.
  from AspNetUsers a
  join ExportBills b on b.ExpEmpId = a.id and b.ExpCusId=a.id

