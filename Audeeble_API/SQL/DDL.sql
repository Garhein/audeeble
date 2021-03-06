﻿
-- ======== --
-- CIVILITE --
-- ======== --

CREATE TABLE [dbo].[T_R_PERS_CIVILITE_PCIV]
(
	[PCIV_ID]			TINYINT NOT NULL,
	[PCIV_ABREVIATION]	CHAR(4) NOT NULL,
	[PCIV_LIBELLE]		CHAR(8) NOT NULL,
	[PCIV_ARCHIVE_ON]	BIT		NOT NULL,
	CONSTRAINT [PK__PCIV] PRIMARY KEY CLUSTERED ([PCIV_ID])
);

ALTER TABLE [dbo].[T_R_PERS_CIVILITE_PCIV]
	  ADD CONSTRAINT [DF__PCIV_PCIV_ABREVIATION] DEFAULT 0 FOR [PCIV_ABREVIATION];


INSERT INTO [dbo].[T_R_PERS_CIVILITE_PCIV] ([PCIV_ID], [PCIV_ABREVIATION], [PCIV_LIBELLE], [PCIV_ARCHIVE_ON])
									VALUES (1, 'M', 'Monsieur', 0);
INSERT INTO [dbo].[T_R_PERS_CIVILITE_PCIV] ([PCIV_ID], [PCIV_ABREVIATION], [PCIV_LIBELLE], [PCIV_ARCHIVE_ON])
									VALUES (2, 'Mme', 'Madame', 0);

-- ======== --
-- PERSONNE --
-- ======== --

CREATE TABLE [dbo].[T_E_PERSONNE_PERS]
(
	[PERS_ID]				INT IDENTITY(1,1),
	[PERS_ARCHIVE_ON]		BIT NOT NULL,
	CONSTRAINT [PK__PERS] PRIMARY KEY CLUSTERED ([PERS_ID])
);

ALTER TABLE [dbo].[T_E_PERSONNE_PERS]
	  ADD CONSTRAINT [DF__PERS_PERS_ARCHIVE_ON] DEFAULT 0 FOR [PERS_ARCHIVE_ON];

-- ================= --
-- PERSONNE PHYSIQUE --
-- ================= --

CREATE TABLE [dbo].[T_E_PERS_PHYSIQUE_PPHY]
(
	[PERS_ID]				INT			NOT NULL,
	[PPHY_NOM_USAGE]		VARCHAR(32) NOT NULL,
	[PPHY_NOM_NAISSANCE]	VARCHAR(32) NOT NULL,
	[PPHY_PRENOM]			VARCHAR(32) NOT NULL,
	[PCIV_ID]				TINYINT		NOT NULL,
	CONSTRAINT [PK__PPHY] PRIMARY KEY CLUSTERED ([PERS_ID])
);

ALTER TABLE [dbo].[T_E_PERS_PHYSIQUE_PPHY]
	  ADD CONSTRAINT [FK__PPHY_PERS_ID] FOREIGN KEY ([PERS_ID]) 
	  REFERENCES [dbo].[T_E_PERSONNE_PERS] ([PERS_ID]);

ALTER TABLE [dbo].[T_E_PERS_PHYSIQUE_PPHY]
	  ADD CONSTRAINT [FK__PPHY_PCIV_ID] FOREIGN KEY ([PCIV_ID]) 
	  REFERENCES [dbo].[T_R_PERS_CIVILITE_PCIV] ([PCIV_ID]);

-- =============== --
-- PERSONNE MORALE --
-- =============== --

CREATE TABLE [dbo].[T_E_PERS_MORALE_PMOR]
(
	[PERS_ID]				INT			NOT NULL,
	[PMOR_RAISON_SOCIALE]	VARCHAR(80) NOT NULL,
	CONSTRAINT [PK__PMOR] PRIMARY KEY CLUSTERED ([PERS_ID])
);

ALTER TABLE [dbo].[T_E_PERS_MORALE_PMOR]
	  ADD CONSTRAINT [FK__PMOR_PERS_ID] FOREIGN KEY ([PERS_ID]) 
	  REFERENCES [dbo].[T_E_PERSONNE_PERS] ([PERS_ID]);