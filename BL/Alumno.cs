﻿namespace BL
{
    public class Alumno
    {
        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.CEGRamosAlfaSolucionesContext context = new DL.CEGRamosAlfaSolucionesContext())
                {
                    var query = (from alumno in context.Alumnos
                                 //join beca in context.Becas on alumno.IdBeca equals beca.IdBeca
                                 select new
                                 {
                                     alumno.IdAlumno,
                                     alumno.Nombre,
                                     alumno.ApellidoPat,
                                     alumno.ApellidoMat,
                                     alumno.Fotografia,
                                     alumno.Sexo,
                                     //alumno.IdBeca,
                                     //beca.NombreBeca,
                                     //beca.MontoMensual
                                 });
                    result.Objects = new List<object>();
                    if(query != null && query.ToList().Count > 0 )
                    {
                        foreach( var obj in query)
                        {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = obj.IdAlumno;
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPat = obj.ApellidoPat;
                            alumno.ApellidoMat = obj.ApellidoMat;
                            alumno.Fotografia = obj.Fotografia;
                            alumno.Sexo = Convert.ToBoolean(obj.Sexo);

                            
                            //alumno.IdBeca = obj.IdBeca.Value;
                            //alumno.Beca.NombreBeca = obj.NombreBeca;
                            //alumno.Beca.MontoMensual = Convert.ToByte(obj.MontoMensual);
                            result.Objects.Add(alumno);
                            result.Correct = true;

                        }
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.MessangeError = "Error al realizar la consulta";
                    }
                }

            }catch (Exception ex)
            {
                result.Correct=false;
                result.MessangeError=ex.Message;
                result.ex=ex;
            }
            return result;
        }

        public static ML.Result GetByIdLINQ(int idalumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CEGRamosAlfaSolucionesContext context = new DL.CEGRamosAlfaSolucionesContext())
                {
                    var query = (from alumno in context.Alumnos
                                 //join beca in context.Becas on alumno.IdBeca equals beca.IdBeca
                                 where alumno.IdAlumno == idalumno
                                 select new
                                 {
                                     alumno.IdAlumno,
                                     alumno.Nombre,
                                     alumno.ApellidoPat,
                                     alumno.ApellidoMat,
                                     alumno.Fotografia,
                                     alumno.Sexo,
                                     //alumno.IdBeca,
                                     //beca.NombreBeca,
                                     //beca.MontoMensual
                                 }).FirstOrDefault();

                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        
                        ML.Alumno alumno = new ML.Alumno();
                        alumno.IdAlumno = query.IdAlumno;
                        alumno.Nombre = query.Nombre;
                        alumno.ApellidoPat = query.ApellidoPat;
                        alumno.ApellidoMat = query.ApellidoMat;
                        alumno.Fotografia = query.Fotografia;
                        alumno.Sexo = Convert.ToBoolean(query.Sexo);

                        
                        //alumno.IdBeca = objalumno.IdBeca.Value;
                        //alumno.Beca.NombreBeca = obj.NombreBeca;
                        //alumno.Beca.MontoMensual = Convert.ToByte(obj.MontoMensual);
                        result.Object = alumno;
                            result.Correct = true;

                        
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.MessangeError = "Error al realizar la consulta";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.MessangeError = ex.Message;
                result.ex = ex;
            }
            return result;
        }

        public static ML.Result AddLINQ(ML.Alumno alumnoMl)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CEGRamosAlfaSolucionesContext context = new DL.CEGRamosAlfaSolucionesContext())
                {
                    DL.Alumno alumnoDL = new DL.Alumno();

                    alumnoDL.Nombre = alumnoMl.Nombre;
                    alumnoDL.ApellidoPat = alumnoMl.ApellidoPat;
                    alumnoDL.ApellidoMat = alumnoMl.ApellidoMat;
                    alumnoDL.Fotografia = alumnoMl.Fotografia;
                    alumnoDL.Sexo = alumnoMl.Sexo;
                    
                    context.Alumnos.Add(alumnoDL);
                    context.SaveChanges();
                    if(alumnoMl != null)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct=false;
                        result.MessangeError = "No ha insertado ningun registro";
                    }
                    result.Correct=true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.MessangeError = ex.Message;
                result.ex = ex;
            }
            return result;
        }

        public static ML.Result UpdateLINQ(ML.Alumno alumnoMl)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CEGRamosAlfaSolucionesContext context = new DL.CEGRamosAlfaSolucionesContext())
                {
                    var query = (from alu in context.Alumnos
                                 where  alu.IdAlumno == alumnoMl.IdAlumno
                                 select alu).FirstOrDefault();



                    if (query != null)
                    {
                        query.Nombre = alumnoMl.Nombre;
                        query.ApellidoPat = alumnoMl.ApellidoPat;
                        query.ApellidoMat = alumnoMl.ApellidoMat;
                        query.Fotografia = alumnoMl.Fotografia;
                        query.Sexo = alumnoMl.Sexo;
                        //query.IdBeca = alumnoMl.IdBeca;

                        context.SaveChanges();
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.MessangeError = "No ha modificado ningun registrado";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.MessangeError = ex.Message;
                result.ex = ex;
            }
            return result;
        }

        public static ML.Result DeleteLINQ(ML.Alumno alumnoMl)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CEGRamosAlfaSolucionesContext context = new DL.CEGRamosAlfaSolucionesContext())
                {
                    var query = (from alu in context.Alumnos
                                 where alu.IdAlumno == alumnoMl.IdAlumno
                                 select alu).First();
                    if (query != null)
                    {
                        context.Alumnos.Remove(query);
                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.MessangeError = "No se eliminado  ningun Registro";

                    }
                    result.Correct = true;



                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.MessangeError = ex.Message;
                result.ex = ex;
            }
            return result;
        }

        public static ML.Result GetAllBecaAlumno()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CEGRamosAlfaSolucionesContext context = new DL.CEGRamosAlfaSolucionesContext())
                {
                    var query = (from alumno in context.Alumnos
                                 join beca in context.Becas on alumno.IdBeca equals beca.IdBeca
                                 select new
                                 {
                                     alumno.IdAlumno,
                                     alumno.Nombre,
                                     alumno.ApellidoPat,
                                     alumno.ApellidoMat,
                                     alumno.Fotografia,
                                     alumno.Sexo,
                                     alumno.IdBeca,
                                     beca.NombreBeca,
                                     beca.MontoMensual
                                 });
                    result.Objects = new List<object>();
                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = obj.IdAlumno;
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPat = obj.ApellidoPat;
                            alumno.ApellidoMat = obj.ApellidoMat;
                            alumno.Fotografia = obj.Fotografia;
                            alumno.Sexo = Convert.ToBoolean(obj.Sexo);


                            alumno.IdBeca = obj.IdBeca.Value;
                            alumno.Beca.NombreBeca = obj.NombreBeca;
                            alumno.Beca.MontoMensual = Convert.ToByte(obj.MontoMensual);
                            result.Objects.Add(alumno);
                            result.Correct = true;

                        }
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.MessangeError = "Error al realizar la consulta";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.MessangeError = ex.Message;
                result.ex = ex;
            }
            return result;
        }


    }
}