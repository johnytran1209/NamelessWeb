
select B.Product, r.ExpCus, r.ExpDes, r.ExpDate, r.ExpEmp, u.Email, u.PhoneNumber
from AspNetUsers U, ExpBillDetails B, ExportBills R 
where r.ExpEmpId = u.Id


update dbo.guitars 
set MDL='{0}', 
BrandId='{1}', TypeId='{2}'
,MSRP='{3}',ELE='{4}'
,WarrId='{5}',ImageLink1='{6}'
,ImageLink2='{7}',ImageLink3='{8}'
,ImageLink4='{9}',ImageLink5='{10}'
,ImageLink6='{11}',VideoLink='{12}'
,Availability='0'  where GuitarId=4

select  G.MDL, g.ImageLink1, U.FullName
from Guitars G, AspNetUsers U
where G.GuitarId='{0}' and u.Id='{1}'

insert into dbo.GuitarRatings values('{0}','{1}','{2}','{3}','{4}')

update dbo.GuitarRatings
set FeedId='{0}', GuitarId='{1}',CusName='{2}',Stars='{3}',FeedMes='{4}'

select g.ImageLink1, d.Product, d.Cost, b.ExpCus, b.ExpDes, b.ExpDate, u.FullName,u.PhoneNumber, D.GuitarId from AspNetUsers U, ExportBills B, ExpBillDetails D, Guitars G where d.GuitarId = g.GuitarId and b.ExpBId = d.ExpBId and b.ExpEmpid = u.Id

select g.ImageLink1,g.MDL, g.GuitarId from Guitars g where g.GuitarId=''

update dbo.GuitarRatings set FeedMes='{0}', Stars='{1}' where FeedId='{2}'

select count(g.FeedId), U.FullName from GuitarRatings G, AspNetUsers U where U.Id='72182fc4-a121-4146-8d25-35403fa3f972'
select  FullName from AspNetUsers where Id=''

select g.FeedId, g.FeedMes,g.CusName,g.Stars from GuitarRatings G where g.GuitarId='4'
select MDL,ImageLink1 from Guitars where GuitarId='4'

select Question from AspNetUsers where Email=''