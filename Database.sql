USE [ShopTest]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2/15/2023 2:16:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Import]    Script Date: 2/15/2023 2:16:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Import](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[import_Date] [date] NOT NULL,
	[staffID] [int] NOT NULL,
	[totalAmount] [float] NULL,
 CONSTRAINT [PK_Import] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImportDetails]    Script Date: 2/15/2023 2:16:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportDetails](
	[quantity] [int] NOT NULL,
	[price_import] [float] NOT NULL,
	[importID] [int] NOT NULL,
	[productID] [int] NOT NULL,
 CONSTRAINT [PK_ImportDetails] PRIMARY KEY CLUSTERED 
(
	[importID] ASC,
	[productID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 2/15/2023 2:16:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[orderID] [int] NOT NULL,
	[productID] [int] NOT NULL,
	[sellPrice] [float] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[orderID] ASC,
	[productID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2/15/2023 2:16:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[orderDate] [datetime] NOT NULL,
	[customerName] [nvarchar](150) NULL,
	[customerAddress] [nvarchar](max) NULL,
	[customerPhone] [nvarchar](50) NULL,
	[totalAmount] [float] NOT NULL,
	[deliverDate] [datetime] NULL,
	[staffID] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2/15/2023 2:16:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [float] NOT NULL,
	[discount] [int] NOT NULL,
	[country] [nvarchar](max) NOT NULL,
	[categoryID] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 2/15/2023 2:16:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[fullname] [nvarchar](150) NOT NULL,
	[phone] [nvarchar](50) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
	[isManager] [bit] NOT NULL,
	[status] [bit] NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [name]) VALUES (1, N'Bim bim')
INSERT [dbo].[Category] ([id], [name]) VALUES (2, N'Nuoc ngot')
INSERT [dbo].[Category] ([id], [name]) VALUES (3, N'bot giat')
INSERT [dbo].[Category] ([id], [name]) VALUES (4, N'giay an')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Import] ON 

INSERT [dbo].[Import] ([id], [import_Date], [staffID], [totalAmount]) VALUES (8, CAST(N'2023-02-09' AS Date), 1, 20000)
SET IDENTITY_INSERT [dbo].[Import] OFF
GO
INSERT [dbo].[ImportDetails] ([quantity], [price_import], [importID], [productID]) VALUES (2, 20000, 8, 2)
GO
INSERT [dbo].[OrderDetails] ([orderID], [productID], [sellPrice], [quantity]) VALUES (12, 1, 90, 1)
INSERT [dbo].[OrderDetails] ([orderID], [productID], [sellPrice], [quantity]) VALUES (12, 2, 10000, 1)
INSERT [dbo].[OrderDetails] ([orderID], [productID], [sellPrice], [quantity]) VALUES (12, 5, 100, 1)
INSERT [dbo].[OrderDetails] ([orderID], [productID], [sellPrice], [quantity]) VALUES (13, 1, 90, 1)
INSERT [dbo].[OrderDetails] ([orderID], [productID], [sellPrice], [quantity]) VALUES (13, 2, 10000, 1)
INSERT [dbo].[OrderDetails] ([orderID], [productID], [sellPrice], [quantity]) VALUES (13, 5, 100, 1)
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([id], [orderDate], [customerName], [customerAddress], [customerPhone], [totalAmount], [deliverDate], [staffID]) VALUES (12, CAST(N'2023-02-09T08:59:28.553' AS DateTime), N'', N'', N'', 10190, NULL, 2)
INSERT [dbo].[Orders] ([id], [orderDate], [customerName], [customerAddress], [customerPhone], [totalAmount], [deliverDate], [staffID]) VALUES (13, CAST(N'2023-02-09T13:08:42.517' AS DateTime), N'', N'', N'', 10190, NULL, 1)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id], [name], [description], [quantity], [price], [discount], [country], [categoryID]) VALUES (1, N'cocacola', N'nuoc ngon', 55, 100, 10, N'viet nam', 2)
INSERT [dbo].[Product] ([id], [name], [description], [quantity], [price], [discount], [country], [categoryID]) VALUES (2, N'bim bim tau', N'trung quoc', 84, 10000, 0, N'china', 1)
INSERT [dbo].[Product] ([id], [name], [description], [quantity], [price], [discount], [country], [categoryID]) VALUES (5, N'fanta', N'nuoc ngot co ga', 6, 100, 0, N'viet name', 2)
INSERT [dbo].[Product] ([id], [name], [description], [quantity], [price], [discount], [country], [categoryID]) VALUES (6, N'Tra Xanh 0 do', N'Nuoc uong giai khat', 20, 10000, 0, N'', 2)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([id], [username], [password], [fullname], [phone], [address], [isManager], [status]) VALUES (1, N'staff', N'123', N'hieu le duc a', N'01215152790', N'Ha Noi', 0, 1)
INSERT [dbo].[Staff] ([id], [username], [password], [fullname], [phone], [address], [isManager], [status]) VALUES (2, N'manager', N'123', N'hieu hihi', N'0131213', N'hanoi', 1, 1)
INSERT [dbo].[Staff] ([id], [username], [password], [fullname], [phone], [address], [isManager], [status]) VALUES (3, N'tien', N'123', N'tien phi', N'0987654321', N'Ha Noi VN', 0, 1)
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
ALTER TABLE [dbo].[Import]  WITH CHECK ADD  CONSTRAINT [FK_Import_Staff] FOREIGN KEY([staffID])
REFERENCES [dbo].[Staff] ([id])
GO
ALTER TABLE [dbo].[Import] CHECK CONSTRAINT [FK_Import_Staff]
GO
ALTER TABLE [dbo].[ImportDetails]  WITH CHECK ADD  CONSTRAINT [FK_ImportDetails_Import] FOREIGN KEY([importID])
REFERENCES [dbo].[Import] ([id])
GO
ALTER TABLE [dbo].[ImportDetails] CHECK CONSTRAINT [FK_ImportDetails_Import]
GO
ALTER TABLE [dbo].[ImportDetails]  WITH CHECK ADD  CONSTRAINT [FK_ImportDetails_Product] FOREIGN KEY([productID])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[ImportDetails] CHECK CONSTRAINT [FK_ImportDetails_Product]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([orderID])
REFERENCES [dbo].[Orders] ([id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Product] FOREIGN KEY([productID])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Product]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Staff] FOREIGN KEY([staffID])
REFERENCES [dbo].[Staff] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Staff]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([categoryID])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
