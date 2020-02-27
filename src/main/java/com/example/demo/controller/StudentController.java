package com.example.demo.controller;

import com.example.demo.dao.StudentJdbc;
import com.example.demo.model.Student;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("student")
public class StudentController {
    private final StudentJdbc studentJdbc;

    public StudentController(StudentJdbc studentJdbc) {
        this.studentJdbc = studentJdbc;
    }

    @GetMapping(value = "/{id}", produces = "application/json")
    public Student getMark(@PathVariable int id){
        Student student = studentJdbc.get(id);
        return student;
    }

    @GetMapping(value = "/all", produces = "application/json")
    public List<Student> getMark(){
        List<Student> student = studentJdbc.getAll();
        return student;
    }
}
