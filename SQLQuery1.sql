select G.GuitarId,G.MDL,G.ImageLink1, U.FullName, u.Email,U.Address, u.PhoneNumber, r.ExpDate
from Guitars G, AspNetUsers U, ExpBillDetails B, ExportBills R 
where G.GuitarId = B.GuitarId and R.ExpCusId= u.Id and r.ExpEmpId = u.Id