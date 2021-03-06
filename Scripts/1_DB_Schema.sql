CREATE DATABASE [Monitoring]
GO

USE [Monitoring]
GO
/****** Object:  Table [dbo].[Action]    Script Date: 12/6/2014 1:38:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Action](
	[IDAction] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NULL,
	[CompOperator] [nvarchar](50) NULL,
	[EventValue] [nvarchar](50) NULL,
	[CallID] [int] NULL,
	[MessageData] [nvarchar](50) NULL,
	[PerValue] [nvarchar](50) NULL,
	[PerTimeValue] [int] NULL,
	[PerTimeUnit] [nvarchar](50) NULL,
	[StartTime] [datetime] NULL,
	[StopTime] [datetime] NULL,
	[TimeZone] [nvarchar](50) NULL,
	[Delay] [int] NULL,
	[EmergencySvcID] [int] NULL,
 CONSTRAINT [PK_Action] PRIMARY KEY CLUSTERED 
(
	[IDAction] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Admin]    Script Date: 12/6/2014 1:38:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OwnerName] [nvarchar](50) NULL,
	[DeviceNumber1] [nvarchar](50) NULL,
	[DeviceNumber2] [nvarchar](50) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CallList]    Script Date: 12/6/2014 1:38:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CallList](
	[IDCallList] [int] IDENTITY(1,1) NOT NULL,
	[CallName] [nvarchar](50) NULL,
	[IdMethod] [int] NULL,
	[CallData] [nvarchar](50) NULL,
 CONSTRAINT [PK_CallList] PRIMARY KEY CLUSTERED 
(
	[IDCallList] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmergencySvc]    Script Date: 12/6/2014 1:38:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmergencySvc](
	[IDEmergencySvc] [int] IDENTITY(1,1) NOT NULL,
	[ESName] [nvarchar](50) NULL,
	[ESNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_EmergencySvc] PRIMARY KEY CLUSTERED 
(
	[IDEmergencySvc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Event]    Script Date: 12/6/2014 1:38:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[IDEvent] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [nvarchar](50) NULL,
	[Monitor] [bit] NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[IDEvent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventListDetail]    Script Date: 12/6/2014 1:38:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventListDetail](
	[IDEventListDetail] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NULL,
	[Sequence] [int] NULL,
	[xmlTag] [nvarchar](50) NULL,
	[EventValue] [int] NULL,
	[EventOperator] [nvarchar](50) NULL,
	[DelayPrior] [int] NULL,
	[EventPer] [int] NULL,
	[EventPerTime] [int] NULL,
	[EventPerTimeUnit] [nvarchar](50) NULL,
 CONSTRAINT [PK_EventListDetail] PRIMARY KEY CLUSTERED 
(
	[IDEventListDetail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Log]    Script Date: 12/6/2014 1:38:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[IDLog] [int] IDENTITY(1,1) NOT NULL,
	[LogTimestamp] [datetime] NULL,
	[xmlTag] [nvarchar](50) NULL,
	[DataValue] [int] NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[IDLog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LookupMethod]    Script Date: 12/6/2014 1:38:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LookupMethod](
	[IDMethod] [int] IDENTITY(1,1) NOT NULL,
	[MethodName] [nvarchar](250) NULL,
 CONSTRAINT [PK_LookupMethod] PRIMARY KEY CLUSTERED 
(
	[IDMethod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Action]  WITH CHECK ADD  CONSTRAINT [FK_Action_CallList] FOREIGN KEY([CallID])
REFERENCES [dbo].[CallList] ([IDCallList])
GO
ALTER TABLE [dbo].[Action] CHECK CONSTRAINT [FK_Action_CallList]
GO
ALTER TABLE [dbo].[Action]  WITH CHECK ADD  CONSTRAINT [FK_Action_EmergencySvc] FOREIGN KEY([EmergencySvcID])
REFERENCES [dbo].[EmergencySvc] ([IDEmergencySvc])
GO
ALTER TABLE [dbo].[Action] CHECK CONSTRAINT [FK_Action_EmergencySvc]
GO
ALTER TABLE [dbo].[Action]  WITH CHECK ADD  CONSTRAINT [FK_Action_Event] FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([IDEvent])
GO
ALTER TABLE [dbo].[Action] CHECK CONSTRAINT [FK_Action_Event]
GO
ALTER TABLE [dbo].[CallList]  WITH CHECK ADD  CONSTRAINT [FK_CallList_LookupMethod] FOREIGN KEY([IdMethod])
REFERENCES [dbo].[LookupMethod] ([IDMethod])
GO
ALTER TABLE [dbo].[CallList] CHECK CONSTRAINT [FK_CallList_LookupMethod]
GO
ALTER TABLE [dbo].[EventListDetail]  WITH CHECK ADD  CONSTRAINT [FK_EventListDetail_Event] FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([IDEvent])
GO
ALTER TABLE [dbo].[EventListDetail] CHECK CONSTRAINT [FK_EventListDetail_Event]
GO
