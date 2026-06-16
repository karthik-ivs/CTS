SELECT
    registration_date,
    COUNT(*) AS users_registered
FROM Users
WHERE registration_date >= CURDATE()-INTERVAL 7 DAY
GROUP BY registration_date;