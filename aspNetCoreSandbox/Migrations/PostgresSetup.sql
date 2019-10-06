DROP TABLE IF EXISTS todo_item;

CREATE TABLE todo_item
(
	id BIGSERIAL PRIMARY KEY,
	text TEXT,
	created_at TIMESTAMP WITHOUT TIME ZONE DEFAULT now()
);
GRANT ALL ON TABLE todo_item TO aspnet;

-- Sample data
INSERT INTO todo_item (text, created_at) VALUES ('Do the dishes', '2019-10-03 12:49:32.000000');
INSERT INTO todo_item (text, created_at) VALUES ('Make the bed', '2019-10-04 12:49:32.000000');
INSERT INTO todo_item (text, created_at) VALUES ('Do the workout', '2019-10-05 12:44:32.000000');