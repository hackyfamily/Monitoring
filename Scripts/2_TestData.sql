USE [Monitoring]
GO
SET IDENTITY_INSERT [dbo].[LookupMethod] ON 

GO
INSERT [dbo].[LookupMethod] ([IDMethod], [MethodName]) VALUES (1, N'Phone')
GO
INSERT [dbo].[LookupMethod] ([IDMethod], [MethodName]) VALUES (2, N'Email')
GO
INSERT [dbo].[LookupMethod] ([IDMethod], [MethodName]) VALUES (3, N'SMS')
GO
SET IDENTITY_INSERT [dbo].[LookupMethod] OFF
GO
SET IDENTITY_INSERT [dbo].[CallList] ON 

GO
INSERT [dbo].[CallList] ([IDCallList], [CallName], [IdMethod], [CallData]) VALUES (1, N'Caregiver', 1, N'540-123-6789')
GO
INSERT [dbo].[CallList] ([IDCallList], [CallName], [IdMethod], [CallData]) VALUES (2, N'Nurse', 2, N'nurse1@gmail.com')
GO
INSERT [dbo].[CallList] ([IDCallList], [CallName], [IdMethod], [CallData]) VALUES (3, N'Mom', 3, N'550-321-9876')
GO
SET IDENTITY_INSERT [dbo].[CallList] OFF 
GO
SET IDENTITY_INSERT [dbo].[EmergencySvc] ON 

GO
INSERT [dbo].[EmergencySvc] ([IDEmergencySvc], [ESName], [ESNumber]) VALUES (1, N'Ambulance', N'551-456-789')
GO
SET IDENTITY_INSERT [dbo].[EmergencySvc] OFF
GO
SET IDENTITY_INSERT [dbo].[Event] ON 

GO
INSERT [dbo].[Event] ([IDEvent], [EventName], [Monitor]) VALUES (1, N'Heart Stop', 1)
GO
INSERT [dbo].[Event] ([IDEvent], [EventName], [Monitor]) VALUES (2, N'Fall', 0)
GO
SET IDENTITY_INSERT [dbo].[Event] OFF
GO
SET IDENTITY_INSERT [dbo].[Action] ON 

GO
INSERT [dbo].[Action] ([IDAction], [EventID], [CompOperator], [EventValue], [CallID], [MessageData], [PerValue], [PerTimeValue], [PerTimeUnit], [StartTime], [StopTime], [TimeZone], [Delay], [EmergencySvcID]) VALUES (1, 1, NULL, NULL, 1, N'Heart Stop Alarm', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Action] OFF
GO
SET IDENTITY_INSERT [dbo].[EventListDetail] ON 

GO
INSERT [dbo].[EventListDetail] ([IDEventListDetail], [EventID], [Sequence], [xmlTag], [EventValue], [EventOperator], [DelayPrior], [EventPer], [EventPerTime], [EventPerTimeUnit]) VALUES (1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[EventListDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

GO
INSERT [dbo].[Admin] ([ID], [OwnerName], [DeviceNumber1], [DeviceNumber2]) VALUES (1, N'Patient1', N'FTBTP01', NULL)
GO
INSERT [dbo].[Admin] ([ID], [OwnerName], [DeviceNumber1], [DeviceNumber2]) VALUES (2, N'Patient2', N'FTBTP02', NULL)
GO
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Log] ON 

GO
INSERT [dbo].[Log] ([IDLog], [LogTimestamp], [xmlTag], [DataValue]) VALUES (1, CAST(N'2014-12-06 00:00:00.000' AS DateTime), N'HeartRate', 80)
GO
INSERT [dbo].[Log] ([IDLog], [LogTimestamp], [xmlTag], [DataValue]) VALUES (2, CAST(N'2014-12-06 00:00:00.000' AS DateTime), N'HeartRate', 82)
GO
INSERT [dbo].[Log] ([IDLog], [LogTimestamp], [xmlTag], [DataValue]) VALUES (3, CAST(N'2014-12-06 00:00:00.000' AS DateTime), N'HeartRate', 94)
GO
INSERT [dbo].[Log] ([IDLog], [LogTimestamp], [xmlTag], [DataValue]) VALUES (4, CAST(N'2014-12-06 00:00:00.000' AS DateTime), N'HeartRate', 140)
GO
SET IDENTITY_INSERT [dbo].[Log] OFF
GO
