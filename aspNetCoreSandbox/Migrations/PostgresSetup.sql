DROP TABLE IF EXISTS crud_item;

CREATE TABLE crud_item
(
	id BIGSERIAL PRIMARY KEY,
	text TEXT
);
GRANT ALL ON TABLE crud_item TO aspnet;

-- Sample data
INSERT INTO crud_item (text) VALUES ('Do the dishes');
INSERT INTO crud_item (text) VALUES ('Make the bed');
INSERT INTO crud_item (text) VALUES ('Do the workout');
