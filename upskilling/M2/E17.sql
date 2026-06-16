SELECT
    speaker_name,
    COUNT(*) AS sessions_handled
FROM Sessions
GROUP BY speaker_name
HAVING COUNT(*) > 1;