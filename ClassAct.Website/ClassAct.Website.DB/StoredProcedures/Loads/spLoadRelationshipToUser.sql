CREATE PROCEDURE [dbo].[spLoadRelationshipToUser]
	@UserID uniqueidentifier
AS
	SELECT p.PersonFirstName, 
	p.PersonLastName, 
	p.PersonsUserName, 
	p.PersonDOB,
	r.[Description]
	from tblPersonRelationship pr
	join tblPerson p on pr.SecondPersonID = p.PersonID
	join tblRelationshipsLookUp r on r.RelationshipTypeID = pr.RelationshipTypeID
	order by r.RelationshipTypeID
RETURN 0
