select g.ImageLink1, d.Product, d.Cost, b.ExpCus, b.ExpDes, b.ExpDate, u.FullName,u.PhoneNumber
from AspNetUsers U, ExportBills B, ExpBillDetails D, Guitars G
where d.GuitarId= g.GuitarId and b.ExpBId=d.ExpBId and b.ExpEmpid=u.Id


