CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

ALTER TABLE "Plots" DROP CONSTRAINT "FK_Plots_Delineations_PositionId";

DROP INDEX "IX_Plots_PositionId";

ALTER TABLE "Plots" DROP COLUMN "PositionId";

ALTER TABLE "Delineations" RENAME COLUMN "Timestamp" TO "Position_Timestamp";

ALTER TABLE "Delineations" RENAME COLUMN "Speed" TO "Position_Speed";

ALTER TABLE "Delineations" RENAME COLUMN "Longitude" TO "Position_Longitude";

ALTER TABLE "Delineations" RENAME COLUMN "Latitude" TO "Position_Latitude";

ALTER TABLE "Delineations" RENAME COLUMN "Course" TO "Position_Course";

ALTER TABLE "Delineations" RENAME COLUMN "Altitude" TO "Position_Altitude";

ALTER TABLE "Delineations" RENAME COLUMN "Accuracy" TO "Position_Accuracy";

ALTER TABLE "Plots" ADD "Position_Accuracy" double precision NULL;

ALTER TABLE "Plots" ADD "Position_Altitude" double precision NULL;

ALTER TABLE "Plots" ADD "Position_Course" double precision NULL;

ALTER TABLE "Plots" ADD "Position_Latitude" double precision NOT NULL DEFAULT 0.0;

ALTER TABLE "Plots" ADD "Position_Longitude" double precision NOT NULL DEFAULT 0.0;

ALTER TABLE "Plots" ADD "Position_Speed" double precision NULL;

ALTER TABLE "Plots" ADD "Position_Timestamp" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '0001-01-01 00:00:00+00:00';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20190329144326_Create base Structure', '2.2.0-rtm-35687');

