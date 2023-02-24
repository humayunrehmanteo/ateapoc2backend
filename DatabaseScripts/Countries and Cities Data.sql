SET IDENTITY_INSERT [dbo].[Cities] ON 
GO
INSERT [dbo].[Cities] ([Id], [CountryId], [Name], [Code], [Latitude], [Longitude]) VALUES (1, 1, N'Islamabad', N'ISB', CAST(33.738045 AS Decimal(10, 6)), CAST(73.084488 AS Decimal(10, 6)))
GO
INSERT [dbo].[Cities] ([Id], [CountryId], [Name], [Code], [Latitude], [Longitude]) VALUES (2, 1, N'Karachi', N'KR', CAST(24.860966 AS Decimal(10, 6)), CAST(66.990501 AS Decimal(10, 6)))
GO
INSERT [dbo].[Cities] ([Id], [CountryId], [Name], [Code], [Latitude], [Longitude]) VALUES (3, 1, N'Peshawar', N'PWR', CAST(34.025917 AS Decimal(10, 6)), CAST(71.560135 AS Decimal(10, 6)))
GO
INSERT [dbo].[Cities] ([Id], [CountryId], [Name], [Code], [Latitude], [Longitude]) VALUES (4, 2, N'Oslo', N'OSL', CAST(59.911491 AS Decimal(10, 6)), CAST(10.757933 AS Decimal(10, 6)))
GO
INSERT [dbo].[Cities] ([Id], [CountryId], [Name], [Code], [Latitude], [Longitude]) VALUES (5, 2, N'Trondheim', N'TR', CAST(63.446827 AS Decimal(10, 6)), CAST(10.421906 AS Decimal(10, 6)))
GO
INSERT [dbo].[Cities] ([Id], [CountryId], [Name], [Code], [Latitude], [Longitude]) VALUES (6, 3, N'Novosibirsk', N'NOVB', CAST(55.018803 AS Decimal(10, 6)), CAST(82.933952 AS Decimal(10, 6)))
GO
INSERT [dbo].[Cities] ([Id], [CountryId], [Name], [Code], [Latitude], [Longitude]) VALUES (7, 3, N'Vorkuta', N'NOVB', CAST(67.496780 AS Decimal(10, 6)), CAST(64.060638 AS Decimal(10, 6)))
GO
INSERT [dbo].[Cities] ([Id], [CountryId], [Name], [Code], [Latitude], [Longitude]) VALUES (8, 3, N'Yekaterinburg', N'YKB', CAST(56.833332 AS Decimal(10, 6)), CAST(60.583332 AS Decimal(10, 6)))
GO
INSERT [dbo].[Cities] ([Id], [CountryId], [Name], [Code], [Latitude], [Longitude]) VALUES (9, 4, N'Copenhagen', N'CPH', CAST(55.676098 AS Decimal(10, 6)), CAST(12.568337 AS Decimal(10, 6)))
GO
INSERT [dbo].[Cities] ([Id], [CountryId], [Name], [Code], [Latitude], [Longitude]) VALUES (10, 4, N'Herning', N'HRN', CAST(56.140934 AS Decimal(10, 6)), CAST(8.968116 AS Decimal(10, 6)))
GO
INSERT [dbo].[Cities] ([Id], [CountryId], [Name], [Code], [Latitude], [Longitude]) VALUES (11, 5, N'Mecca', N'MC', CAST(21.422510 AS Decimal(10, 6)), CAST(39.826168 AS Decimal(10, 6)))
GO
INSERT [dbo].[Cities] ([Id], [CountryId], [Name], [Code], [Latitude], [Longitude]) VALUES (12, 5, N'Riyadh', N'RY', CAST(24.774265 AS Decimal(10, 6)), CAST(46.738586 AS Decimal(10, 6)))
GO
INSERT [dbo].[Cities] ([Id], [CountryId], [Name], [Code], [Latitude], [Longitude]) VALUES (13, 5, N'Medina', N'MD', CAST(24.470901 AS Decimal(10, 6)), CAST(39.612236 AS Decimal(10, 6)))
GO
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 
GO
INSERT [dbo].[Countries] ([Id], [Name], [Code]) VALUES (1, N'Pakistan', N'PK')
GO
INSERT [dbo].[Countries] ([Id], [Name], [Code]) VALUES (2, N'Norway', N'NW')
GO
INSERT [dbo].[Countries] ([Id], [Name], [Code]) VALUES (3, N'Russia', N'RU')
GO
INSERT [dbo].[Countries] ([Id], [Name], [Code]) VALUES (4, N'Denmark', N'DK')
GO
INSERT [dbo].[Countries] ([Id], [Name], [Code]) VALUES (5, N'Saudi Arabia', N'SA')
GO
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
