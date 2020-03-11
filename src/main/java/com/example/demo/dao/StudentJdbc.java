package com.example.demo.dao;

import com.example.demo.model.Student;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.simple.SimpleJdbcInsert;
import org.springframework.stereotype.Repository;

import javax.sql.DataSource;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@Repository
public class StudentJdbc {

    private final JdbcTemplate jdbcTemplate;
    private final SimpleJdbcInsert simpleJdbcInsert;

    public StudentJdbc(DataSource dataSource) {
        this.jdbcTemplate = new JdbcTemplate(dataSource);
        this.simpleJdbcInsert = new SimpleJdbcInsert(dataSource)
                .withTableName("Student")
                .usingGeneratedKeyColumns("id");
    }

    public long create(Student student) {
        Map<String, Object> parameters = new HashMap<>();

        parameters.put("surname", student.getSurname());
        parameters.put("name", student.getName());
        parameters.put("second_name", student.getSecond_name());
        parameters.put("study_group_id", student.getStudy_group_id());

        return simpleJdbcInsert.executeAndReturnKey(parameters).longValue();
    }

    public List<Student> getAll() {
        return jdbcTemplate.query(
                "SELECT student.id, surname, student.name, second_name, study_group_id, study_group.name " +
                "AS study_group " +
                        "FROM student INNER JOIN study_group ON student.study_group_id = study_group.id",
                this::mapStudent
        );
    }

    public List<Student> getAllLocal() {
        return jdbcTemplate.query(
                "SELECT student_local.id, surname, student_local.name, second_name, study_group_id, " +
                        "study_group.name " +
                        "AS study_group " +
                        "FROM student_local INNER JOIN study_group ON student_local.study_group_id = study_group.id",
                this::mapStudent
        );
    }

    public Student get(int id) {
        return jdbcTemplate.queryForObject(
                "SELECT student.id, surname, student.name, second_name, study_group_id, study_group.name " +
                        "AS study_group " +
                        "FROM student INNER JOIN study_group ON student.study_group_id = study_group.id " +
                        "WHERE student.id = ?",
                this::mapStudent,
                id
        );
    }

    public List<Student> getAllByStudyGroup(int studyGroupId) {
        return jdbcTemplate.query(
                "SELECT student.id, surname, student.name, second_name, study_group_id, study_group.name " +
                        "AS study_group " +
                        "FROM student INNER JOIN study_group ON student.study_group_id = study_group.id " +
                        "WHERE study_group_id = ?",
                this::mapStudent,
                studyGroupId
        );
    }

    private Student mapStudent(ResultSet rs, int i) throws SQLException {
        return new Student(
                rs.getInt("id"),
                rs.getString("surname"),
                rs.getString("name"),
                rs.getString("second_name"),
                rs.getInt("study_group_id"),
                rs.getString("study_group")
        );
    }

    public int update(int id, Student student) {
        return jdbcTemplate.update(
                "UPDATE student SET surname = ?, name = ?, second_name = ?, study_group_id = ? WHERE id = ?",
                student.getSurname(),
                student.getName(),
                student.getSecond_name(),
                student.getStudy_group_id(),
                id
        );
    }

    public int transfer(int id, int studyGroupId) {
        return jdbcTemplate.update(
                "UPDATE student SET study_group_id = ? WHERE id = ?",
                studyGroupId,
                id
        );
    }

    public int delete(int id) {
        return jdbcTemplate.update(
                "DELETE FROM student WHERE id = ?",
                id
        );
    }
}
