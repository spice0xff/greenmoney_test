SELECT
	[ID],
	SUM([ID]) OVER(
		ORDER BY [ID]
	) AS accumulation
FROM [greenmoney].[dbo].[Table_a]
WHERE UserId=86
