----------
CREATE TRIGGER trg_UpdateTimeAdd
ON dbo.tbl_user
AFTER UPDATE	
AS
    UPDATE dbo.tbl_user
    SET date_reg = GETDATE()
    WHERE userid IN (SELECT DISTINCT userId FROM Inserted)
----------------------------------------------------
Insert Into dbo.tbl_user ([userId],[password],[email],[role],[date_reg]) 
values ('test2' , 'test1' , 'test1@test1' , 3  , GETDATE());
go
----------------check exist---
IF EXISTS ( SELECT *	FROM [tbl_user] WHERE tbl_user.userId = 'testuser' AND tbl_user.password = 'Testuser1234')
Begin 
	print	'exist'
End
--------------------PROCEDURE------------------------
CREATE PROCEDURE register_user
	@UserName varchar(50), @UserPassword varchar(50), 
	@UserEmail varchar(250), @FullName varchar(50),
	@Address nvarchar(250), @Phone varchar(15),
	@Gender int, @Role int
AS 
	Insert Into dbo.tbl_user ([userId],[password],[email],[fullname],[address],[phone],[gender],[role],[date_reg])
	values (@UserName,  @UserPassword, @UserEmail, @FullName, @Address, @Phone, @Gender, @Role, GETDATE());
GO


---use LoginDB------

Create Procedure getInfo3
@username varchar(50),
@password varchar(50) OUTPUT
as
	select @password = password from tbl_users where username = @username

go
/*run procedure*/
getInfo

------use output parameter---------------
Declare @Pass varchar(50)
execute getInfo3 'ngoc', @password = @Pass OUTPUT
print 'Pass is ' + @Pass
go


--- không cần thiết phải làm trigger cho insert một dòng vào bảng order thì nó lấy ngày hiện tại
-- chỉ cần để giá trị default của nó là GETDATE() là được 
-- đã test cách này thành công

create procedure insertOrder
@user varchar(50),
@orderId varchar(50),
@totalAmount varchar(50)
as
	insert into tbl_order(username,orderID,totalAmount)
	values(@user,@orderId,@totalAmount)
go

insertOrder 'ngoc','ngoc3',25

create trigger insertNewOrder
ON tbl_order
after INSERT
AS
Begin
	update tbl_order
	set date = GETDATE()
	where orderID = 
end

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-----QUAN----------------------------------------------
--GetAllRole--view_GetAllRole
SELECT name
FROM tbl_role
--GetImageOfPost
CREATE PROCEDURE GetImageOfPost
@postId int
AS
	SELECT url
	FROM [tbl_image]
	WHERE postId = @postId
GO

--DeleteImage
CREATE PROCEDURE DeleteImage
@ImageId int
AS
	DELETE 
	FROM [tbl_image]
	WHERE imageId = @ImageId
GO
--Get a Post by postID
CREATE PROCEDURE GetPostById
@Id int
AS
	SELECT * 
	FROM [tbl_post]
	WHERE postId = @Id
GO
--Delete Post 
CREATE PROCEDURE DeletePost
@Id int
AS
	DELETE 
	FROM [tbl_post]
	WHERE postId = @Id
GO
--Get all comment of post 
CREATE PROCEDURE GetPostComment
@PostId int
AS
	SELECT *
	FROM [tbl_comment]
	WHERE postId = @PostId
GO
--Get comment of a comment
CREATE PROCEDURE GetCommentOfComment
@CoId int
AS
	SELECT *
	FROM [tbl_comment]
	WHERE parentId = @CoId
GO
--Delete comment 
CREATE PROCEDURE DeleteComment
@CoId int
AS
	DELETE
	FROM [tbl_comment]
	WHERE id = @CoId
GO
--Edit comment
CREATE PROCEDURE UpdateComment
@CoId int, @Title nvarchar(50), @Content nvarchar(MAX)
AS
	UPDATE [tbl_comment]
	SET	tbl_comment.title = @Title, tbl_comment.commentContent = @Content ,  tbl_comment.time=GETDATE()
	WHERE id = @CoId
GO
--Login 
CREATE PROCEDURE CheckLogin
@Role int OUTPUT,
@UserName varchar(50), @Password varchar(50)
AS
	BEGIN
		IF EXISTS (		SELECT *	FROM [tbl_user] WHERE tbl_user.userId = @UserName AND tbl_user.password=@Password	)
			SET @Role =  (		SELECT role	FROM [tbl_user] WHERE tbl_user.userId = @UserName AND tbl_user.password=@Password	);
		ELSE
			SET @Role = 0;
	END
--Change Password
CREATE PROCEDURE ChangePassword
@UserId varchar(50), @newPass varchar(50)
AS
	UPDATE [tbl_user]
	SET	[tbl_user].password = @newPass
	WHERE userId = @UserId
GO
--Get users by name
CREATE PROCEDURE GetUserByName
@FullName nvarchar(50)
AS
	SELECT *
	FROM [tbl_user]
	WHERE tbl_user.fullname like @FullName
GO
--Get list product with discount and time sale --View_ProductSale
SELECT dbo.tbl_product.*, dbo.tbl_product_deal.discount, dbo.tbl_product_deal.type, dbo.tbl_deal.startTime, dbo.tbl_deal.duration
FROM            dbo.tbl_deal INNER JOIN
                         dbo.tbl_product_deal ON dbo.tbl_deal.id = dbo.tbl_product_deal.dealId INNER JOIN
                         dbo.tbl_product ON dbo.tbl_product_deal.productId = dbo.tbl_product.productId
WHERE dbo.tbl_product.productId = dbo.tbl_product_deal.	productId	
--Add product
CREATE PROCEDURE AddProduct
@Name nvarchar(50), 
@Brand nvarchar(50), 
@Price money, 
@Country nvarchar(50), 
@Description nvarchar(MAX),
@Material nvarchar(50), 
@Color nvarchar(50), 
@CategoryId int, 
@Quantity int
AS
	INSERT INTO tbl_product(name,brand,price,country,description,material,color,categoryID,quantity)
	VALUES (@Name,@Brand,@Price,@Country,@Description,@Material,@Color,@CategoryId,@Quantity)
GO
--Update product information	
CREATE PROCEDURE UpdateProduct
@Id int, @Name nvarchar(50), @Brand nvarchar(50), @Price money, @Country nvarchar(50), @Description nvarchar(MAX),
@Material nvarchar(50), @Color nvarchar(50), @CategoryId int, @Quantity int
AS
	UPDATE [tbl_product]
	SET	tbl_product.name = @Name, tbl_product.brand = @Brand, tbl_product.country = @Country, tbl_product.price = @Price, 
		tbl_product.description = @Description, tbl_product.material = @Material, tbl_product.color = @Color, tbl_product.categoryID = @CategoryId, tbl_product.quantity = @Quantity
	WHERE tbl_product.productId = @Id
GO	
--Add order
CREATE PROCEDURE AddOrder
@TotalPrice money, 
@UserId varchar(50), 
@OrderId int OUTPUT
AS
	INSERT INTO tbl_order(date,totalPrice,status,userId)
	VALUES (GETDATE(), @TotalPrice, 1, @UserId) --------not approve --------------
	SELECT @OrderId = SCOPE_IDENTITY()
    SELECT @OrderId AS id
GO
--Update order status (staff)
CREATE PROCEDURE UpdateOrderStatus
@Status int, @Id int
AS
	UPDATE [tbl_order]
	SET	tbl_order.status = @Status
	WHERE tbl_order.id = @Id
GO	
--Delete order (staff)
CREATE PROCEDURE DeleteOrder
@Id int
AS
	select *
	FROM tbl_order
	WHERE orderId = @Id
GO
--Add deal
CREATE PROCEDURE AddDeal
@DealContent nvarchar(50), @StartTime datetime, @Duration int,
@DealId int OUTPUT
AS
	INSERT INTO tbl_deal(dealContent,startTime,duration)
	VALUES (@DealContent,@StartTime,@Duration)
	SELECT @DealId = SCOPE_IDENTITY()
    SELECT @DealId AS id
GO
--Delete Deal
CREATE PROCEDURE DeleteDeal
@Id int
AS
	DELETE
	FROM [tbl_deal]
	WHERE tbl_deal.id = @Id
GO
--Get deal are activity
CREATE PROCEDURE IsDealAlive
@IsLive int OUTPUT,
@Id int
AS
	BEGIN
		IF EXISTS (		SELECT *	FROM [tbl_deal] WHERE tbl_deal.id = @Id	)
			SET @IsLive =  (		SELECT (tbl_deal.startTime + tbl_deal.duration) - GETDATE()
									FROM [tbl_deal] WHERE tbl_deal.id = @Id );
		ELSE
			SET @IsLive = -999;
	END
GO
--Get products with deal
CREATE PROCEDURE GetProductOfDeal
@DealId int
AS
	SELECT *
	FROM [tbl_product_deal]
	WHERE tbl_product_deal.dealId = @DealId
GO
--Add product are allow in voucher
CREATE PROCEDURE AddProductVoucher
@VoucherId varchar(50), @ProductId int
AS
	INSERT INTO tbl_voucher_product(voucherId,productId)
	VALUES (@VoucherId,@ProductId)
GO
--Update voucher
CREATE PROCEDURE UpdateVoucher
@Id int, @type bit, @discount int, @description nvarchar(250), 
@startTime datetime, @duration int, @amount int
AS
	UPDATE dbo.tbl_voucher
	SET	dbo.tbl_voucher.type = @type, dbo.tbl_voucher.discount = @discount, dbo.tbl_voucher.description = @description,
		dbo.tbl_voucher.startTime = @startTime, dbo.tbl_voucher.duration = @duration, dbo.tbl_voucher.amount =@amount
	WHERE dbo.tbl_voucher.voucherId = @Id
GO
--Get all voucher
SELECT *
FROM dbo.tbl_voucher
--Add Category
CREATE PROCEDURE AddCategory
@Name varchar(50), @Description varchar(150), @ParentId int
AS
	INSERT INTO tbl_category(name,description,parentId)
	VALUES (@Name,@Description,@ParentId)
GO
--Update Category
CREATE PROCEDURE UpdateCategory
@Id int, @Name varchar(50), @Description varchar(150), @ParentId int
AS
	UPDATE dbo.tbl_category
	SET dbo.tbl_category.name=@Name,
		dbo.tbl_category.description=@Description,
		dbo.tbl_category.parentId=@ParentId
	WHERE dbo.tbl_category.id=@Id
GO
------------------NGOC --------------------------------------------------
--------------VIEW----------------------
CREATE VIEW [dbo].[ListAllComment]
AS
SELECT        dbo.tbl_user.fullname, dbo.tbl_comment.title, dbo.tbl_comment.commentContent, dbo.tbl_comment.time
FROM            dbo.tbl_comment INNER JOIN
                         dbo.tbl_user ON dbo.tbl_comment.authorId = dbo.tbl_user.userId

GO
CREATE VIEW [dbo].[ListAllPost]
AS
SELECT        dbo.tbl_post.postId, dbo.tbl_post.title, dbo.tbl_post.timePost, dbo.tbl_user.fullname
FROM            dbo.tbl_post INNER JOIN
                         dbo.tbl_user ON dbo.tbl_post.userId = dbo.tbl_user.userId

GO
CREATE VIEW [dbo].[ListAllUser]
AS
SELECT        dbo.tbl_role.name, dbo.tbl_user.userId, dbo.tbl_user.email, dbo.tbl_user.fullname, dbo.tbl_user.phone, dbo.tbl_user.gender
FROM            dbo.tbl_role INNER JOIN
                         dbo.tbl_user ON dbo.tbl_role.roleid = dbo.tbl_user.role

GO
CREATE VIEW [dbo].[ListOrderWithVoucher]
AS
SELECT        dbo.tbl_order.id, dbo.tbl_order.userId, dbo.tbl_order.date, dbo.tbl_order.totalPrice, dbo.tbl_voucher.discount, dbo.tbl_voucher.voucherId, dbo.tbl_order.status, dbo.tbl_order.approveder_id
FROM            dbo.tbl_order INNER JOIN
                         dbo.tbl_order_status ON dbo.tbl_order.status = dbo.tbl_order_status.order_statusId INNER JOIN
                         dbo.tbl_order_voucher ON dbo.tbl_order.id = dbo.tbl_order_voucher.orderId INNER JOIN
                         dbo.tbl_voucher ON dbo.tbl_order_voucher.voucherId = dbo.tbl_voucher.voucherId

GO
CREATE VIEW [dbo].[ListProductWithDeal]
AS
SELECT        dbo.tbl_product.name, dbo.tbl_product.price, dbo.tbl_image.url, dbo.tbl_product_deal.discount
FROM            dbo.tbl_product INNER JOIN
                         dbo.tbl_product_deal ON dbo.tbl_product.productId = dbo.tbl_product_deal.productId INNER JOIN
                         dbo.tbl_image ON dbo.tbl_product.productId = dbo.tbl_image.productId INNER JOIN
                         dbo.tbl_deal ON dbo.tbl_product_deal.dealId = dbo.tbl_deal.id
WHERE        (dbo.tbl_deal.startTime > DATEDIFF(hour, dbo.tbl_deal.duration, GETDATE()))

GO

--------------PROCEDURE-----------------
----- get role name ---------
select name
from tbl_role
where roleid = 1
------ get image of product ------
select url
from tbl_image
where productId = 1
---------- add image ---------
create procedure AddImageOfProduct
@Url varchar(255),
@ProductId int
AS
	INSERT INTO tbl_image(url, productId)
	VALUES (@Url, @ProductId)
GO

create procedure AddImageOfPost
@Url varchar(255),
@PostId int
AS
	INSERT INTO tbl_image(url, postId)
	VALUES (@Url, @PostId)
GO

--------- Update Post ------------
create procedure UpdatePost
@Title nvarchar(50),
@Content nvarchar(MAX),
@PostId int
AS
	UPDATE tbl_post
	SET title = @Title, postContent = @Content
	WHERE postId = @PostId
GO

--------- Add Post --------------
create procedure AddPost
@Title nvarchar(50),
@Content nvarchar(MAX),
@UserId varchar(50)
AS
	INSERT INTO tbl_post(title, postContent, timePost, userId)
	VALUES(@Title, @Content, GETDATE(), @UserId)
GO

---------Add Comment -------------
create procedure AddCommentOFProduct
@Title nvarchar(50),
@Content nvarchar(MAX),
@ProductId int, 
@AuthorId varchar(50)
AS
	INSERT INTO tbl_comment(title, commentContent, productId, time, authorId)
	VALUES (@Title, @Content, @ProductId, GETDATE(), @AuthorId)
GO

create procedure AddCommentOFPost
@Title nvarchar(50),
@Content nvarchar(MAX),
@PostId int, 
@AuthorId varchar(50)
AS
	INSERT INTO tbl_comment(title, commentContent, postId, time, authorId)
	VALUES (@Title, @Content, @PostId, GETDATE(), @AuthorId)
GO

create procedure ReplyComment --Reply ko có title
@Content nvarchar(MAX), 
@ParentId int,
@AuthorId varchar(50)
AS
	INSERT INTO tbl_comment(commentContent, parentId, time, authorId)
	VALUES ( @Content, @ParentId, GETDATE(), @AuthorId)
GO

-------- Add Account --------------
create procedure AddAccount
@UserId varchar(50),
@Password varchar(50),
@Email varchar(250),
@Fullname varchar(50),
@Address nvarchar(250),
@Phone varchar(15),
@Gender int, 
@Role int
AS
	INSERT INTO tbl_user(userId, password, email, fullname, address, phone, gender, role, date_reg)
	VALUES (@UserId, @Password, @Email, @Fullname, @Address, @Phone, @Gender, GETDATE())
GO

--------------Update Profile ---------------
create procedure UpdateProfile
@UserId varchar(50),
@Password varchar(50),
@Email varchar(250),
@Fullname varchar(50),
@Address nvarchar(250),
@Phone varchar(15),
@Gender int, 
@Role int
AS
	UPDATE tbl_user
	SET email = @Email, 
		phone = @Phone, 
		fullname = @Fullname, 
		address = @Address, 
		gender = @Gender
	WHERE userId = @UserId
GO

create procedure ChangeRole
@UserId varchar(50),
@Role int
AS
	UPDATE tbl_user
	SET role = @Role
	WHERE role = @Role
GO

----------- delete product ------------
create procedure DeleteProduct
@ProductId int
AS
	DELETE 
	FROM tbl_product
	WHERE productId = @ProductId
GO

----------- update quantity product -----------
create procedure UpdateQuantityProduct
@ProductId int,
@Quantity int
AS
	UPDATE tbl_product
	SET quantity = @Quantity
	WHERE productId = @ProductId
GO
------------ cancel order ---------------
create procedure CancelOrder
@OrderId int
AS
	UPDATE tbl_order
	SET status =  5 --status Cancel -----
	WHERE id = @OrderId
GO

---------- add deal for each product -------------
create procedure AddDealForProduct
@DealId int,
@ProductId int,
@Discount int,
@Type bit
AS
	INSERT INTO tbl_product_deal(productId, discount, type)
	VALUES (@ProductId, @Discount, @Type)
GO

------------ update deal --------------
create procedure UpdateDealInformation
@DealId int,
@Content nvarchar(50),
@StartTime datetime,
@Duration int
AS
	UPDATE tbl_deal
	SET dealContent = @Content, startTime = @StartTime, duration = @Duration
	WHERE id = @DealId
GO

create procedure ChangeProductDiscount
@DealId int,
@ProductId int,
@Discount int,
@Type bit
AS
	UPDATE tbl_product_deal
	SET discount = @Discount, type = @Type
	WHERE productId = @ProductId AND dealId = @DealId
GO

---------- add product for voucher ---------
create procedure AddProductOfVoucher
@Voucher varchar(50),
@ProductId int
AS
	INSERT INTO tbl_voucher_product(voucherId, productId)
	VALUES(@Voucher, @ProductId)
GO

--------- delete voucher ---------------
create procedure DeleteVoucher
@VoucherId int
AS
	DELETE 
	FROM tbl_voucher
	WHERE voucherId = @VoucherId
GO
-----------register-------------------

create procedure AddUser
@Username varchar(50),
@Password varchar(50),
@Fullname nvarchar(50),
@Phone varchar(15),
@Email varchar(250),
@Address nvarchar(250)
AS
	INSERT INTO tbl_user(userId, password, fullname, email, phone, address, role)
	VALUES (@Username, @Password, @Fullname, @Email, @Phone, @Address, 3)
GO

AddUser 'ngoc','123','Nguyễn Thúy Ngọc','123456','ngoc@com','132acv'

----------------- delete category ----------------------
create procedure DeleteCategory
@CategoryId int
AS
	DELETE 
	FROM tbl_category
	WHERE id = @CategoryId
GO

--------------- delete account (expired user)----------------------
create procedure ExpiredUser
@UserId varchar(50)
AS
	UPDATE tbl_user
	SET expired = 1
	WHERE userId = @UserId
GO

--------------- get comment product ----------------
create procedure GetProductComment
@ProductId int
AS
	SELECT *
	FROM ListAllComment
	WHERE productId = @ProductId
GO
---------------get user by role -----------------------
create procedure GetUserByRole
@Role int
AS
	SELECT *
	FROM tbl_user
	WHERE role = @Role
GO
---------------get user by username -----------------------
create procedure GetUserByUsername
@Username varchar(50)
AS
	SELECT *
	FROM tbl_user
	WHERE userId = @Username
GO
---------------		get all category ----------------
create procedure GetAllCategory
AS
	SELECT id, name
	FROM tbl_category
	ORDER BY name ASC
GO

----------------- get history order ------------------
create procedure GetHistoryOrderOfUser
@Username varchar(50)
AS
	SELECT *
	FROM ListOrderWithVoucher
	WHERE userId = @Username
	ORDER BY date DESC
GO

-------------- get detail of order ---------------------
create procedure GetDetailOfOrder
@OrderId int,
@Username varchar(50)
AS
	SELECT *
	FROM ListOrderWithVoucher
	WHERE id = @OrderId AND userId = @Username
GO

----------------get list product in order ---------------
create procedure GetListProductInOrder
@OderId int
AS
	SELECT *
	FROM ProductInOrder
	WHERE orderId = @OderId
GO

------------------ add voucher order -----------------------
create procedure AddVoucherOrder
@VoucherId varchar(50),
@OrderId int
AS
	INSERT INTO tbl_order_voucher
	VALUES(@VoucherId, @OrderId)
	--reduce quantity of voucher
	UPDATE tbl_voucher
	SET quantity = quantity - 1
	WHERE voucherId = @VoucherId

GO
------------------- add order product -------------------
create procedure AddOrderProduct
@OrderId int,
@ProductId int,
@Quantity int
AS
	INSERT INTO tbl_orderDetail
	VALUES (@OrderId, @ProductId, @Quantity)
	--- reduce quantity of product
	UPDATE tbl_product
	SET quantity = quantity - @Quantity
	WHERE productId = @ProductId
GO
---------------get first image of product ---------------
create procedure GetFirstImageOfProduct
@ProductId int
AS
	SELECT TOP 1 url
	FROM tbl_image
	WHERE productId = @ProductId
GO

--------------get detail of product -------------------------
create procedure GetProductDetail
@ProductId int
AS
	SELECT *
	FROM ProductDetail
	WHERE productId = @ProductId
GO

------------get size of product -------------------
create procedure GetProductSize
@ProductId int
AS
	SELECT *
	FROM ProducSize
	WHERE productId = @ProductId
GO
------------get color of product -----------------
create procedure GetProductColor
@ProductId int
AS
	SELECT *
	FROM ProductColor
	WHERE productId = @ProductId
GO
--------------- search product by name ---------------
create procedure SearchProductByName
@SearchValue nvarchar(250)
AS
	SELECT *
	FROM ListProductWithDeal
	WHERE name like '%'+@SearchValue + '%'
	ORDER BY name asc
GO
----------------- get list product sort by discount ---------------
create procedure GetProductsSortByDiscount
AS
	SELECT *
	FROM ListProductWithDeal
	ORDER BY discount DESC
GO
-----------DROP STORE PROCEDURE----------------
DROP Procedure if exists GetAllDeal


CREATE PROCEDURE DeleteProductDeal
@Id int, @ProductId int
AS
	DELETE
	FROM tbl_product_deal
	WHERE tbl_product_deal.dealId = @Id AND tbl_product_deal.productId = @ProductId
GO

CREATE VIEW [dbo].[ProductDetail]
AS
SELECT        dbo.tbl_product.productId, dbo.tbl_product.name, dbo.tbl_product.brand, dbo.tbl_product.price, dbo.tbl_product.country, dbo.tbl_product.description, dbo.tbl_product.material, dbo.tbl_product.quantity, 
                         dbo.tbl_product_deal.discount, dbo.tbl_product_deal.type, dbo.tbl_deal.startTime, dbo.tbl_deal.duration
FROM            dbo.tbl_deal INNER JOIN
                         dbo.tbl_product_deal ON dbo.tbl_deal.id = dbo.tbl_product_deal.dealId INNER JOIN
                         dbo.tbl_product ON dbo.tbl_product_deal.productId = dbo.tbl_product.productId
WHERE        (GETDATE() > dbo.tbl_deal.startTime) AND (GETDATE() < DATEADD(hour, dbo.tbl_deal.duration, dbo.tbl_deal.startTime))

GO

create procedure GetImageOfProduct
@ProductId int
AS
		SELECT url
		FROM tbl_image
		WHERE productId = @ProductId
GO

CREATE PROCEDURE ProductListByCategory
@CategoryId int
AS
SELECT *
FROM dbo.tbl_product
WHERE dbo.tbl_product.categoryID = @CategoryId
GO

use snkrkorea
create procedure GetAllDeal
AS
	Select *
	From tbl_deal
GO

create procedure GetAllVoucher
AS
	SELECT *
	FROM tbl_voucher
GO

GetAllVoucher
GetPostById 1
alter procedure GetAllProductForUser
AS
	SELECT *
	FROM ListProductWithDeal
	ORDER BY name asc
GO

GetAllProductForUser
GetProductsSortByDiscount
SearchProductByName 'o'

----------get product with first image and deal---------
select t3.productId, t3.name, t3.price, t3.url, v1.discount, v1.type,t3.lastModified
from (
	select t1.productId,url,name,price,t2.lastModified
	from (
		select productId as productId, max(url) as url
		from ListProductWithImage
		group by productId
		) t1 
		INNER JOIN 
		tbl_product t2 
		ON t1.productId = t2.productId
 ) t3 
 LEFT OUTER JOIN 
 ListProductWithDeal v1 
 ON t3.productId = v1.productId
 order by lastModified desc

 select *
 from ListProductItem
 order by lastModified desc
 select *
 from ListProductWithImage

 GetAllProductForUser

 ProductListByCategory 5

 SearchProductByName '%áo thun%'
