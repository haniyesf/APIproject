
/************************
Tables
************************/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_mal_Permission_aspnet_Applications]') AND parent_object_id = OBJECT_ID(N'[dbo].[mal_Permissions]'))
ALTER TABLE [dbo].[mal_Permissions] DROP CONSTRAINT [FK_mal_Permission_aspnet_Applications]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_mal_PermissionsInRoles_aspnet_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[mal_PermissionsInRoles]'))
ALTER TABLE [dbo].[mal_PermissionsInRoles] DROP CONSTRAINT [FK_mal_PermissionsInRoles_aspnet_Roles]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_mal_PermissionsInRoles_mal_Permission]') AND parent_object_id = OBJECT_ID(N'[dbo].[mal_PermissionsInRoles]'))
ALTER TABLE [dbo].[mal_PermissionsInRoles] DROP CONSTRAINT [FK_mal_PermissionsInRoles_mal_Permission]
GO
/****** Objet :  Table [dbo].[mal_Permissions]    Date de génération du script : 11/22/2009 15:02:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mal_Permissions]') AND type in (N'U'))
DROP TABLE [dbo].[mal_Permissions]
GO
/****** Objet :  Table [dbo].[mal_PermissionsInRoles]    Date de génération du script : 11/22/2009 15:02:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mal_PermissionsInRoles]') AND type in (N'U'))
DROP TABLE [dbo].[mal_PermissionsInRoles]
GO

/****** Objet :  Table [dbo].[mal_Permissions]    Date de génération du script : 11/22/2009 15:02:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mal_Permissions](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[PermissionId] [uniqueidentifier] NOT NULL CONSTRAINT [DF_mal_Permission_PermissionId]  DEFAULT (newid()),
	[PermissionName] [nvarchar](256) COLLATE French_CI_AS NULL,
	[LoweredPermissionName] [nvarchar](256) COLLATE French_CI_AS NULL,
	[Description] [nvarchar](256) COLLATE French_CI_AS NULL,
 CONSTRAINT [PK_mal_Permission] PRIMARY KEY CLUSTERED 
(
	[PermissionId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Objet :  Table [dbo].[mal_PermissionsInRoles]    Date de génération du script : 11/22/2009 15:02:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mal_PermissionsInRoles](
	[PermissionId] [uniqueidentifier] NULL,
	[RoleId] [uniqueidentifier] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[mal_Permissions]  WITH CHECK ADD  CONSTRAINT [FK_mal_Permission_aspnet_Applications] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[mal_PermissionsInRoles]  WITH CHECK ADD  CONSTRAINT [FK_mal_PermissionsInRoles_aspnet_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[aspnet_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[mal_PermissionsInRoles]  WITH CHECK ADD  CONSTRAINT [FK_mal_PermissionsInRoles_mal_Permission] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[mal_Permissions] ([PermissionId])
GO

/************************
Views
************************/
/****** Objet :  View [dbo].[vw_mal_UserPermissions]    Date de génération du script : 11/22/2009 15:02:56 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_mal_UserPermissions]'))
DROP VIEW [dbo].[vw_mal_UserPermissions]
GO

/****** Objet :  View [dbo].[vw_mal_UserPermissions]    Date de génération du script : 11/22/2009 15:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_mal_UserPermissions]
AS
SELECT     dbo.aspnet_Users.ApplicationId, dbo.aspnet_Users.UserId, dbo.mal_Permissions.PermissionId, dbo.mal_Permissions.PermissionName, 
                      dbo.mal_Permissions.LoweredPermissionName, dbo.mal_Permissions.Description
FROM         dbo.aspnet_Users INNER JOIN
                      dbo.aspnet_UsersInRoles ON dbo.aspnet_Users.UserId = dbo.aspnet_UsersInRoles.UserId INNER JOIN
                      dbo.aspnet_Roles ON dbo.aspnet_UsersInRoles.RoleId = dbo.aspnet_Roles.RoleId INNER JOIN
                      dbo.mal_PermissionsInRoles ON dbo.aspnet_Roles.RoleId = dbo.mal_PermissionsInRoles.RoleId INNER JOIN
                      dbo.mal_Permissions ON dbo.mal_PermissionsInRoles.PermissionId = dbo.mal_Permissions.PermissionId

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "aspnet_Users"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 104
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "aspnet_UsersInRoles"
            Begin Extent = 
               Top = 6
               Left = 268
               Bottom = 91
               Right = 460
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "aspnet_Roles"
            Begin Extent = 
               Top = 6
               Left = 498
               Bottom = 121
               Right = 690
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "mal_PermissionsInRoles"
            Begin Extent = 
               Top = 112
               Left = 272
               Bottom = 197
               Right = 464
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "mal_Permissions"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 241
               Right = 237
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1995
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'vw_mal_UserPermissions'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'350
         Or = 1350
         Or = 1350
      End
   End
End
' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'vw_mal_UserPermissions'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'vw_mal_UserPermissions'
GO

/************************
Store procedures
************************/

GO
/****** Objet :  StoredProcedure [dbo].[mal_GetPermissionsForUser]    Date de génération du script : 11/28/2009 14:56:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mal_GetPermissionsForUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[mal_GetPermissionsForUser]
GO
/****** Objet :  StoredProcedure [dbo].[mal_PermissionsInRole_AddPermissionToRole]    Date de génération du script : 11/28/2009 14:56:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mal_PermissionsInRole_AddPermissionToRole]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[mal_PermissionsInRole_AddPermissionToRole]
GO
/****** Objet :  StoredProcedure [dbo].[mal_UserHasPermission]    Date de génération du script : 11/28/2009 14:56:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mal_UserHasPermission]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[mal_UserHasPermission]


GO
/****** Objet :  StoredProcedure [dbo].[mal_GetPermissionsForUser]    Date de génération du script : 11/28/2009 14:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[mal_GetPermissionsForUser]	
    @ApplicationName  nvarchar(256),
	@UserName         nvarchar(256)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(1)
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL

    SELECT  @UserId = UserId
    FROM    dbo.aspnet_Users
    WHERE   LoweredUserName = LOWER(@UserName) AND ApplicationId = @ApplicationId

    IF (@UserId IS NULL)
        RETURN(1)

    -- Insert statements for procedure here
	SELECT  vw_mal_UserPermissions.PermissionName
	FROM vw_mal_UserPermissions 
	WHERE vw_mal_UserPermissions.UserId = @UserId
	AND vw_mal_UserPermissions.ApplicationId = @ApplicationId

	RETURN (0)
END




GO
/****** Objet :  StoredProcedure [dbo].[mal_PermissionsInRole_AddPermissionToRole]    Date de génération du script : 11/28/2009 14:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[mal_PermissionsInRole_AddPermissionToRole]
	-- Add the parameters for the stored procedure here
	@ApplicationName	nvarchar(256),
	@PermissionName		nvarchar(4000),
	@RoleName			nvarchar(4000)
AS
BEGIN
	DECLARE @ApplicationId uniqueidentifier
	SELECT  @ApplicationId = NULL
	SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
	
	IF (@ApplicationId IS NULL)
		RETURN(2)	

	DECLARE @PermissionId uniqueidentifier
    SELECT  @PermissionId = NULL
    SELECT  @PermissionId = PermissionId
    FROM    dbo.mal_permissions
    WHERE   LoweredPermissionName = LOWER(@PermissionName) AND ApplicationId = @ApplicationId
	
	IF (@PermissionId IS NULL)
        RETURN(3)

	DECLARE @RoleId uniqueidentifier
    SELECT  @RoleId = NULL
    SELECT  @RoleId = RoleId
    FROM    dbo.aspnet_Roles
    WHERE   LoweredRoleName = LOWER(@RoleName) AND ApplicationId = @ApplicationId

	IF (@RoleId IS NULL)
        RETURN(4)

	DECLARE @TranStarted   bit
	SET @TranStarted = 0

	IF( @@TRANCOUNT = 0 )
	BEGIN
		BEGIN TRANSACTION
		SET @TranStarted = 1
	END	

	INSERT INTO dbo.mal_PermissionsInRoles (PermissionId, RoleId)
	VALUES(@PermissionId,@RoleId)
	IF( @TranStarted = 1 )
		COMMIT TRANSACTION
	RETURN(0)
END

GO
/****** Objet :  StoredProcedure [dbo].[mal_UserHasPermission]    Date de génération du script : 11/28/2009 14:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[mal_UserHasPermission]	
    @ApplicationName  nvarchar(256),
	@UserName         nvarchar(256),
	@PermissionName         nvarchar(256)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(2)
    
	DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL  
    SELECT  @UserId = UserId
    FROM    dbo.aspnet_Users
    WHERE   LoweredUserName = LOWER(@UserName) AND ApplicationId = @ApplicationId
    IF (@UserId IS NULL)
        RETURN(3)

	DECLARE @PermissionId uniqueidentifier
    SELECT  @PermissionId = NULL
    SELECT  @PermissionId = PermissionId
    FROM    dbo.mal_permissions
    WHERE   LoweredPermissionName = LOWER(@PermissionName) AND ApplicationId = @ApplicationId

    IF (@PermissionId IS NULL)
        RETURN(4)

	IF (EXISTS
	(
		SELECT  vw_mal_UserPermissions.PermissionName 
		FROM vw_mal_UserPermissions 
		WHERE vw_mal_UserPermissions.UserId = @UserId
		AND vw_mal_UserPermissions.ApplicationId = @ApplicationId
		and vw_mal_UserPermissions.PermissionId = @PermissionId
	))
		return 1
	else
		return 0
END



/****** Object:  StoredProcedure [dbo].[mal_UserAuthenticate]    Script Date: 04/03/2010 13:36:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mal_UserAuthenticate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[mal_UserAuthenticate]
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[mal_UserAuthenticate]
	-- Add the parameters for the stored procedure here
	@ApplicationName  nvarchar(256),
	@UserName         nvarchar(256),
	@Password         nvarchar(128)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF Exists(
		SELECT aspnet_Applications.ApplicationName, aspnet_Users.UserName
		, aspnet_Membership.[Password]
		FROM aspnet_Users 
		INNER JOIN aspnet_Applications 
			ON aspnet_Users.ApplicationId = aspnet_Applications.ApplicationId
		INNER JOIN aspnet_Membership 
			ON aspnet_Users.UserId = aspnet_Membership.UserId 
			AND aspnet_Applications.ApplicationId = aspnet_Membership.ApplicationId
		Where aspnet_Applications.ApplicationName = @ApplicationName
		And aspnet_Users.UserName = @UserName
		And aspnet_Membership.[Password] = @Password
	)
	Begin
		Return 1
	End
	Else
		Return 0
        
        
END

GO



