(function () {
    /** Meeting Controller
     *
     * @param $location:
     * @param MeetingAdmin: Service
     * @constructor
     */
    function MeetingAddController($location, $scope, MeetingAdmin, $stateParams) {
        var self = this;
        self.error = '';
        self.debug = '';
        self.isNew = false;
        self.info = MeetingAdmin.info;
 
        self.meeting = MeetingAdmin.create();
   
        self.meetingId = $stateParams.meetingId;
        self.steps = [];

        self.addMeeting = function (meeting) {
            return MeetingAdmin.addMeeting(meeting);

        }

        self.isValid = function () {
            return true;
        };

        if (self.meetingId) {
            self.meeting = MeetingAdmin.get($stateParams.meetingId);
            //self.meeting.$promise.then(function (result) {
            //});

        } else {
            self.isNew = true;
            self.meeting = MeetingAdmin.create();
        }

     
        self.deleteConf = function (idx, meeting) {

            MeetingAdmin.deleteConf(idx, meeting);
            $scope.$apply()

        };

        self.save = function () {
            if (!self.isValid()) {
                return false;
            }
            var success_url = '/meetings';
            if (self.configurationId) {
                success_url = success_url + '/' + self.meeting;

                console.log(success_url);
            }
            if (self.isNew) {
                self.meeting.$save(function (response) {
                    console.log(response);
                    
                        $location.path(success_url);
                    
               
                });
            } else {
                self.meeting.$update(function (response) {
                    console.log(response);
                    if (response.status == 0) {
                        $location.path(success_url);
                    } else {
                        self.error = response.error;
                        self.debug = response.debug;
                    }
                });
            }
        };










    }

    angular.module('eli.admin')
        .controller('MeetingAddController', ['$location', '$scope', 'MeetingAdmin', '$stateParams', MeetingAddController]);
}());










