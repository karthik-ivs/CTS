SELECT title
FROM Events
WHERE event_id =
(
    SELECT event_id
    FROM Sessions
    GROUP BY event_id
    ORDER BY COUNT(*) DESC
    LIMIT 1
);