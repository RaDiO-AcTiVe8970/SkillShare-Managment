import axios from 'axios';

export default function InsProfile( {data} ) {
    return(
        <>
            <h1>InsProfile</h1>
            {data.flatMap(instructor =>(
                <div key={instructor.InstructorId}>
                    <h2>{instructor.InstructorName}</h2>
                    <p>{instructor.InstructorEmail}</p>
                    <p>{instructor.InstructorPassword}</p>
                    <p>{instructor.InstructorPhoneNumber}</p>
                    <p>{instructor.InstructorStatus}</p>
                    <p>{instructor.InstructorAccountStatus}</p>
                    <p>{instructor.RegistrationDate}</p>
                </div>
            ))}
        </>
    );
}

export async function getServerSideProps() 
{
    const response = await axios.get('http://localhost:53721/api/Instructor/GetIns/1',
    {
        headers: { 'Content-Type': 'application/json' }
    });
    const data = await response.data;
    return { props: { data } }
}