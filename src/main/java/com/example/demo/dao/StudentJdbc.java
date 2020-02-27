package com.example.demo.dao;

import com.example.demo.model.Student;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.stereotype.Repository;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;

@Repository
public class StudentJdbc {
    private final JdbcTemplate jdbcTemplate;

    public StudentJdbc(JdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }

    public Student get(int id) {
        return jdbcTemplate.queryForObject("SELECT * FROM student WHERE id = ?", this::mapStudent, id);
    }

    public List<Student> getAll(){
        return jdbcTemplate.query("SELECT * FROM student", mapStudentList);
    }

    private Student mapStudent(ResultSet resultSet, int i) throws SQLException {
        Student student = new Student(
                resultSet.getInt("id"),
                resultSet.getString("surname"),
                resultSet.getString("name"),
                resultSet.getString("second_name"),
                resultSet.getInt("study_group_id")
        );
        return student;
    }

    private RowMapper<Student> mapStudentList = (ResultSet resultSet, int rowNum) -> {
        return mapStudent(resultSet,rowNum);
    };
}
