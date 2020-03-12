using System;
using System.Collections.Generic;
using System.Text;

namespace StudyDepartment.BusClient.Enum
{
    public enum Subjects
    {
        INIT_INSTANCE,
        ADD_INSTANCE,
        REMOVE_INSTANCE,

        ADD_ENTITY,
        REMOVE_ENTITY,

        UPDATE_SUBSCRIPTION,
        CREATE_ENTITY,
        ADD_ROW,
        REMOVE_ROW,

        ECHO_REQUEST,
        ECHO_RESPONSE,
        ERROR_RESPONSE
    }
}
