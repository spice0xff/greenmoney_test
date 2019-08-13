SELECT TOP 1 [ID], [Status]
FROM [greenmoney].[dbo].[Table_a]
WHERE UserId=85
ORDER BY id DESC


--Не подойдет, если id не инкрементный.
SELECT [ID], [Status]
FROM [greenmoney].[dbo].[Table_a]
WHERE [ID] IN (
	SELECT max([ID])
	FROM [greenmoney].[dbo].[Table_a]
	WHERE UserId=85
)
