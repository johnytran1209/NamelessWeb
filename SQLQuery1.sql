select B.Product, r.ExpCus, r.ExpDes,
from AspNetUsers U, ExpBillDetails B, ExportBills R 
where R.ExpCusId= u.Id and r.ExpEmpId = u.Id