DROP TABLE IF EXISTS crud_item;

CREATE TABLE crud_item
(
	id BIGSERIAL PRIMARY KEY,
	text TEXT
);

GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO aspnet;
GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public TO aspnet;

-- Sample data
INSERT INTO crud_item (text) VALUES ('Do the dishes');
INSERT INTO crud_item (text) VALUES ('Make the bed');
INSERT INTO crud_item (text) VALUES ('Do the workout');
