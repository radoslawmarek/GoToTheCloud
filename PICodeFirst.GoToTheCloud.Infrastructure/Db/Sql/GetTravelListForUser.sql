SELECT t.id, 
	t.description,
	t.start,
	t.finish,
	t.user_id,
	t.location_from_id,
	t.location_to_id,
	lf.name as location_from_name,
	lt.name as location_to_name
FROM Travels t
INNER JOIN Locations lf ON (lf.id = t.location_from_id)
INNER JOIN Locations lt ON (lt.id = t.location_to_id)
WHERE t.user_id = @user_id