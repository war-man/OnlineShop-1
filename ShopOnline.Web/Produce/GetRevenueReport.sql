CREATE PROC GetRevenueDaily
	@fromDate VARCHAR(10),
	@toDate VARCHAR(10)
AS
BEGIN
		  select
                CAST(b.DateCreated AS DATE) as Date,
                sum(bd.ProductQuantity*bd.ProductLastPrice) as Revenue,
                sum((bd.ProductQuantity*bd.ProductPrice)-(bd.ProductQuantity * bd.ProductPrice)) as Profit
                from Orders b
                inner join dbo.OrderDetails bd
                on b.Id = bd.OrderId
                inner join Products p
                on bd.ProductId  = p.Id
                where b.DateCreated <= cast(@toDate as date) 
				AND b.DateCreated >= cast(@fromDate as date)
                group by b.DateCreated
END
EXEC dbo.GetRevenueDaily @fromDate = '12/01/2019',
                         @toDate = '2/25/2022'