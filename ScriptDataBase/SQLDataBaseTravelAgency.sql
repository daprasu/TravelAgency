USE [AgenciaViajesSmart]
GO
/****** Object:  Table [dbo].[DocumentType]    Script Date: 10/12/2023 10:51:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](256) NOT NULL,
 CONSTRAINT [PK_DocumentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guest]    Script Date: 10/12/2023 10:51:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](256) NOT NULL,
	[SecondName] [varchar](256) NULL,
	[FirstSurname] [varchar](256) NOT NULL,
	[SecondSurname] [varchar](256) NULL,
	[Gender] [bit] NOT NULL,
	[DocumentTypeId] [int] NOT NULL,
	[DocumentNumber] [int] NOT NULL,
	[Email] [varchar](256) NOT NULL,
	[PhoneNumber] [int] NOT NULL,
	[EmergencyContact] [varchar](256) NOT NULL,
	[EmergencyNumber] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ReservationId] [int] NOT NULL,
 CONSTRAINT [PK_Guest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 10/12/2023 10:51:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HotelName] [varchar](256) NOT NULL,
	[UserId] [int] NOT NULL,
	[NIT] [varchar](256) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[City] [varchar](256) NOT NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 10/12/2023 10:51:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cost] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[NumberPeople] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 10/12/2023 10:51:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomCode] [varchar](256) NOT NULL,
	[BaseCost] [int] NOT NULL,
	[Taxes] [int] NOT NULL,
	[Floor] [varchar](256) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[HotelId] [int] NOT NULL,
	[RoomTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 10/12/2023 10:51:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomEspecification] [varchar](256) NOT NULL,
	[Capacity] [int] NOT NULL,
 CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/12/2023 10:51:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](256) NOT NULL,
	[Password] [varchar](256) NOT NULL,
	[Email] [varchar](256) NOT NULL,
	[Code] [varchar](256) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DocumentType] ON 
GO
INSERT [dbo].[DocumentType] ([Id], [Name]) VALUES (1, N'Cedula Ciudadania')
GO
INSERT [dbo].[DocumentType] ([Id], [Name]) VALUES (2, N'Cedula Extranjera')
GO
SET IDENTITY_INSERT [dbo].[DocumentType] OFF
GO
SET IDENTITY_INSERT [dbo].[Guest] ON 
GO
INSERT [dbo].[Guest] ([Id], [FirstName], [SecondName], [FirstSurname], [SecondSurname], [Gender], [DocumentTypeId], [DocumentNumber], [Email], [PhoneNumber], [EmergencyContact], [EmergencyNumber], [UserId], [ReservationId]) VALUES (1, N'Cristian', N'David', N'Prada', N'Suarez', 1, 1, 111, N'email', 123456, N'emergencia', 235, 1, 1)
GO
INSERT [dbo].[Guest] ([Id], [FirstName], [SecondName], [FirstSurname], [SecondSurname], [Gender], [DocumentTypeId], [DocumentNumber], [Email], [PhoneNumber], [EmergencyContact], [EmergencyNumber], [UserId], [ReservationId]) VALUES (2, N'Cristian', N'David', N'Prada', N'Suarez', 1, 1, 111, N'email', 123456, N'emergencia', 235, 1, 2)
GO
INSERT [dbo].[Guest] ([Id], [FirstName], [SecondName], [FirstSurname], [SecondSurname], [Gender], [DocumentTypeId], [DocumentNumber], [Email], [PhoneNumber], [EmergencyContact], [EmergencyNumber], [UserId], [ReservationId]) VALUES (3, N'angelica', N'patricia', N'celis', N'prada', 1, 1, 111, N'email', 123456, N'emergencia', 235, 1, 2)
GO
SET IDENTITY_INSERT [dbo].[Guest] OFF
GO
SET IDENTITY_INSERT [dbo].[Hotel] ON 
GO
INSERT [dbo].[Hotel] ([Id], [HotelName], [UserId], [NIT], [Enabled], [City]) VALUES (1, N'Las Venturas', 2, N'99-9', 1, N'Floridablanca')
GO
INSERT [dbo].[Hotel] ([Id], [HotelName], [UserId], [NIT], [Enabled], [City]) VALUES (2, N'Holiday in', 2, N'12-3', 1, N'Bucaramanga')
GO
INSERT [dbo].[Hotel] ([Id], [HotelName], [UserId], [NIT], [Enabled], [City]) VALUES (3, N'Hotel Caribean', 2, N'12345-6', 0, N'Cartagena')
GO
INSERT [dbo].[Hotel] ([Id], [HotelName], [UserId], [NIT], [Enabled], [City]) VALUES (4, N'Hotel Roseliere', 3, N'2222-2', 1, N'Bucaramanga')
GO
SET IDENTITY_INSERT [dbo].[Hotel] OFF
GO
SET IDENTITY_INSERT [dbo].[Reservation] ON 
GO
INSERT [dbo].[Reservation] ([Id], [Cost], [StartDate], [EndDate], [NumberPeople], [RoomId]) VALUES (1, 110000, CAST(N'2023-12-10T03:04:15.017' AS DateTime), CAST(N'2023-12-11T03:04:15.017' AS DateTime), 1, 1)
GO
INSERT [dbo].[Reservation] ([Id], [Cost], [StartDate], [EndDate], [NumberPeople], [RoomId]) VALUES (2, 560000, CAST(N'2023-12-11T03:04:15.017' AS DateTime), CAST(N'2023-12-15T03:04:15.017' AS DateTime), 2, 3)
GO
SET IDENTITY_INSERT [dbo].[Reservation] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 
GO
INSERT [dbo].[Room] ([Id], [RoomCode], [BaseCost], [Taxes], [Floor], [Enabled], [HotelId], [RoomTypeId]) VALUES (1, N'204', 100000, 10000, N'2', 1, 1, 1)
GO
INSERT [dbo].[Room] ([Id], [RoomCode], [BaseCost], [Taxes], [Floor], [Enabled], [HotelId], [RoomTypeId]) VALUES (2, N'1003', 500000, 50000, N'10', 1, 3, 3)
GO
INSERT [dbo].[Room] ([Id], [RoomCode], [BaseCost], [Taxes], [Floor], [Enabled], [HotelId], [RoomTypeId]) VALUES (3, N'1004', 500000, 60000, N'10', 1, 3, 4)
GO
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
SET IDENTITY_INSERT [dbo].[RoomType] ON 
GO
INSERT [dbo].[RoomType] ([Id], [RoomEspecification], [Capacity]) VALUES (1, N'Estandar con cama doble', 2)
GO
INSERT [dbo].[RoomType] ([Id], [RoomEspecification], [Capacity]) VALUES (2, N'Estandar con 2 camas sencillas', 2)
GO
INSERT [dbo].[RoomType] ([Id], [RoomEspecification], [Capacity]) VALUES (3, N'Multiple con una cama doble y dos sencillas', 4)
GO
INSERT [dbo].[RoomType] ([Id], [RoomEspecification], [Capacity]) VALUES (4, N'Suite con cama doble', 2)
GO
SET IDENTITY_INSERT [dbo].[RoomType] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [UserName], [Password], [Email], [Code]) VALUES (1, N'Guest 1', N'1234', N'Email@gmail.com', N'Guest')
GO
INSERT [dbo].[User] ([Id], [UserName], [Password], [Email], [Code]) VALUES (2, N'Administrador', N'2345', N'Email2@gmai.com', N'Admin')
GO
INSERT [dbo].[User] ([Id], [UserName], [Password], [Email], [Code]) VALUES (3, N'Administrado2', N'0000', N'Email3@gmail.com', N'Admin')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Hotel] ADD  CONSTRAINT [DF_Hotel_Enabled]  DEFAULT ((1)) FOR [Enabled]
GO
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [DF_Room_Enabled]  DEFAULT ((1)) FOR [Enabled]
GO
ALTER TABLE [dbo].[Guest]  WITH CHECK ADD  CONSTRAINT [FK_Guest_DocumentType] FOREIGN KEY([DocumentTypeId])
REFERENCES [dbo].[DocumentType] ([Id])
GO
ALTER TABLE [dbo].[Guest] CHECK CONSTRAINT [FK_Guest_DocumentType]
GO
ALTER TABLE [dbo].[Guest]  WITH CHECK ADD  CONSTRAINT [FK_Guest_Reservation] FOREIGN KEY([ReservationId])
REFERENCES [dbo].[Reservation] ([Id])
GO
ALTER TABLE [dbo].[Guest] CHECK CONSTRAINT [FK_Guest_Reservation]
GO
ALTER TABLE [dbo].[Guest]  WITH CHECK ADD  CONSTRAINT [FK_Guest_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Guest] CHECK CONSTRAINT [FK_Guest_User]
GO
ALTER TABLE [dbo].[Hotel]  WITH CHECK ADD  CONSTRAINT [FK_Hotel_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Hotel] CHECK CONSTRAINT [FK_Hotel_User]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Room]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Hotel] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotel] ([Id])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Hotel]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomType] FOREIGN KEY([RoomTypeId])
REFERENCES [dbo].[RoomType] ([Id])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_RoomType]
GO
