CREATE TABLE dbo.Robot
(
	RobotId INT IDENTITY(1,1) NOT NULL,
	Name VARCHAR(500) NOT NULL,
	Code VARCHAR(200) NOT NULL
)
GO
ALTER TABLE dbo.Robot ADD CONSTRAINT PK_Robot_RobotId PRIMARY KEY(RobotId)
GO
ALTER TABLE dbo.Robot ADD CONSTRAINT UQ_Robot_Code UNIQUE(Code)
GO

CREATE TABLE dbo.GridObstacle
(
	GridObstacleId INT IDENTITY(1,1) NOT NULL,
	Name VARCHAR(500) NOT NULL,
	Code VARCHAR(200) NOT NULL
)
GO
ALTER TABLE dbo.GridObstacle ADD CONSTRAINT PK_GridObstacle_GridObstacleId PRIMARY KEY(GridObstacleId)
GO
ALTER TABLE dbo.GridObstacle ADD CONSTRAINT UQ_GridObstacle_Code UNIQUE(Code)
GO

CREATE TABLE dbo.GridObstacleBehaviour
(
	GridObstacleBehaviourId INT IDENTITY(1,1) NOT NULL,
	Description VARCHAR(MAX),
	Code VARCHAR(200) NOT NULL,
)
GO
ALTER TABLE dbo.GridObstacleBehaviour ADD CONSTRAINT PK_GridObstacleBehaviour_GridObstacleBehaviourId PRIMARY KEY(GridObstacleBehaviourId)
GO
ALTER TABLE dbo.GridObstacleBehaviour ADD CONSTRAINT UQ_GridObstacleBehaviour_Code UNIQUE(Code)
GO

CREATE TABLE dbo.LinkRobotGridObstacleBehaviour
(
	LinkRobotGridObstacleBehaviourId INT IDENTITY(1,1) NOT NULL,
	RobotId INT NOT NULL,
	GridObstacleId INT NOT NULL,
	GridObstacleBehaviourId INT NOT NULL
)
GO
ALTER TABLE dbo.LinkRobotGridObstacleBehaviour ADD CONSTRAINT PK_LinkRobotGridObstacleBehaviour_LinkRobotGridObstacleBehaviourId PRIMARY KEY(LinkRobotGridObstacleBehaviourId)
GO
ALTER TABLE dbo.LinkRobotGridObstacleBehaviour ADD CONSTRAINT UQ_LinkRobotGridObstacleBehaviour_RobotId_GridObstacleId UNIQUE(RobotId,GridObstacleId) 
GO
ALTER TABLE dbo.LinkRobotGridObstacleBehaviour ADD CONSTRAINT FK_LinkRobotGridObstacleBehaviour_RobotId FOREIGN KEY (RobotId) REFERENCES dbo.Robot(RobotId)
GO
ALTER TABLE dbo.LinkRobotGridObstacleBehaviour ADD CONSTRAINT FK_LinkRobotGridObstacleBehaviour_GridObstacleId FOREIGN KEY (GridObstacleId) REFERENCES dbo.GridObstacle(GridObstacleId)
GO
ALTER TABLE dbo.LinkRobotGridObstacleBehaviour ADD CONSTRAINT FK_LinkRobotGridObstacleBehaviour_GridObstacleBehaviourId FOREIGN KEY (GridObstacleBehaviourId) REFERENCES dbo.GridObstacleBehaviour(GridObstacleBehaviourId)
GO



INSERT INTO dbo.Robot(Name,Code) VALUES('Robot 1','R1')
GO

INSERT INTO dbo.GridObstacle(Name,Code) VALUES('Rock','1')
GO
INSERT INTO dbo.GridObstacle(Name,Code) VALUES('Hole','2')
GO
INSERT INTO dbo.GridObstacle(Name,Code) VALUES('Spinner','3')
GO

INSERT INTO dbo.GridObstacleBehaviour(Description,Code) VALUES('Go back to Start Position','OB1')
GO
INSERT INTO dbo.GridObstacleBehaviour(Description,Code) VALUES('Cannot Move','OB2')
GO
INSERT INTO dbo.GridObstacleBehaviour(Description,Code) VALUES('Clock Wise 90 degree spin','OB3')
GO

CREATE PROCEDURE dbo.LinkRobotGridObstacleBehaviour_Insert
(
	@RobotCode VARCHAR(200),
	@ObstacleCode VARCHAR(200),
	@ObstacleBehaviourCode VARCHAR(200)
)
AS
BEGIN
	
	DECLARE @RobotId INT,@ObstacleId INT,@ObstacleBehaviourId INT

	SELECT @RobotId = RobotId FROM dbo.Robot WHERE Code = @RobotCode
	SELECT @ObstacleId = GridObstacleId FROM dbo.GridObstacle WHERE Code = @ObstacleCode
	SELECT @ObstacleBehaviourId = GridObstacleBehaviourId FROM dbo.GridObstacleBehaviour WHERE Code = @ObstacleBehaviourCode 


	INSERT INTO dbo.LinkRobotGridObstacleBehaviour(RobotId,GridObstacleId,GridObstacleBehaviourId) VALUES(@RobotId,@ObstacleId,@ObstacleBehaviourId)


END
GO

EXEC dbo.LinkRobotGridObstacleBehaviour_Insert @RobotCode='R1',@ObstacleCode = '1',@ObstacleBehaviourCode = 'OB2'
GO
EXEC dbo.LinkRobotGridObstacleBehaviour_Insert @RobotCode='R1',@ObstacleCode = '2',@ObstacleBehaviourCode = 'OB1'
GO
EXEC dbo.LinkRobotGridObstacleBehaviour_Insert @RobotCode='R1',@ObstacleCode = '3',@ObstacleBehaviourCode = 'OB3'
GO


CREATE PROCEDURE dbo.LinkRobotGridObstacleBehaviour_Get
(
	@RobotCode VARCHAR(200),
	@GridObstacleCode VARCHAR(200)
)
AS
BEGIN

	SELECT
		r.Code AS RobotCode,
		o.Name AS ObstacleName,
		o.Code AS ObstacleCode,
		ob.Description AS ObstacleBehaviourDescription,
		ob.Code AS ObstacleBehaviourCode
	FROM dbo.LinkRobotGridObstacleBehaviour link
	INNER JOIN dbo.Robot r ON r.RobotId = link.RobotId
	INNER JOIN dbo.GridObstacle o ON o.GridObstacleId = link.GridObstacleId
	INNER JOIN dbo.GridObstacleBehaviour ob ON ob.GridObstacleBehaviourId = link.GridObstacleBehaviourId
	WHERE r.Code = @RobotCode AND o.Code = @GridObstacleCode


END
GO

CREATE PROCEDURE dbo.Robot_GetAll
AS
BEGIN

	SELECT
		RobotId,
		Name,
		Code
	FROM dbo.Robot

END
GO

CREATE PROCEDURE dbo.GridObstacle_GetAll
AS
BEGIN
	
	SELECT
		GridObstacleId,
		Name,
		Code
	FROM dbo.GridObstacle


END